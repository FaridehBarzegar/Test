using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Test.Pages
{
    public class MemorandomPage
    {
        private IWebDriver driver;
        private  WebDriverWait webDriverWait;
        private IWebElement m_ObjTo => driver.FindElement( By.Id( "To_text" ) );
        private IWebElement m_ObjTranscriptItems0TranscriptToAsPosition => driver.FindElement( By.Id( "TranscriptItems_0_TranscriptToAsPosition_text" ) );
        private IWebElement m_TxtTranscriptItems0TranscriptReason => driver.FindElement( By.Id( "TranscriptItems_0__TranscriptReason" ) );
        private IWebElement m_BtnAdd => driver.FindElement( By.Id( "add" ) );
        private IWebElement m_ChckCopyMemorandom => driver.FindElement( By.XPath( "//div[@id='memorandum-button-wrapper']/div[1]/div[@class='table-cell']" ) );
        // private IWebElement m_ChckAdditionalData_HasTranscriptFollowUp => driver.FindElement( By.XPath( "//div[@class='icheckbox_minimal-purple checked']/ins[@class='iCheck-helper']" ));
        private IWebElement m_Txtmemorandumtitle => driver.FindElement( By.Id( "memorandum-title" ) );
        private IWebElement m_Btnimportanceflag => driver.FindElement( By.ClassName( "importance-flag" ) );
        private IWebElement m_CkEditor => driver.FindElement( By.Id( "cke_1_top" ) );
        private IWebElement m_ContentMemorandom => driver.FindElement( By.CssSelector( "#cke_1_contents > iframe" ) );
        public MemorandomPage( IWebDriver driver )
        {
            this.driver = driver;
            //NewMemorandomLoaded( );
        }

        public void NewMemorandomLoaded( )
        {
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ) );
            IWebElement m_ObjTo= webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.Id( "To_text" )));
            Assert.AreEqual( true, m_ObjTo.Displayed );
            Assert.AreEqual( true, m_ObjTranscriptItems0TranscriptToAsPosition.Displayed );
            Assert.AreEqual( true, m_TxtTranscriptItems0TranscriptReason.Displayed );
            Assert.AreEqual( true, m_BtnAdd.Enabled );
            Assert.AreEqual( true, m_ChckCopyMemorandom.Displayed );
            //Assert.AreEqual( "", m_ChckAdditionalData_HasTranscriptFollowUp.Text );
            Assert.AreEqual( true, m_Txtmemorandumtitle.Displayed );
            Assert.AreEqual( true, m_Btnimportanceflag.Displayed );
            Assert.AreEqual( true, m_CkEditor.Displayed );
            Assert.AreEqual( true, m_ContentMemorandom.Displayed );
        }

        public void SaveNewMemorandom( )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            m_ObjTo.Click( );
            m_ObjTo.SendKeys( "فر" );
            driver.FindElement( By.XPath( "//li[.='فرزانه رحيمي مسئول دفتر']" ) );
            //// driver.FindElement( By.XPath( " //ul[contains(.,'رضا  احمدي مديرعاملعليرضا  لطفي انتظاماتمحمد  رضايي رئيس هيئت مديرهمحمدرضا كوثري')]" ) );
            //// driver.FindElement( By.XPath( " //div[@id='To_objectPicker']//div[.='رضا  احمدي مديرعامل']" ) ).Click( );
            m_Txtmemorandumtitle.SendKeys( "درخواست تهیه گزارش ماهانه سود و زیان" );
            driver.SwitchTo( ).Frame( m_ContentMemorandom );
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys( " لطفا گزارش ماهانه سود و زیان بابت قلم دارایی بدهی بانک مرکزی تهیه گردیده و به واحد صورت مالی تحویل داده شود.باتشکر.          " );
            driver.SwitchTo( ).ParentFrame( );

            DateTime fromDateTime = DateTime.Now;
            driver.FindElement( By.Id( "f8f76661-500a-4ed5-bcd4-bd1db55c96bf-label" ) ).Click( );
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );

            //string dbDate = "1402/01/28 03:21 ب.ظ";
            //var date = dbDate.Split(" ")[0];
            //var time = dbDate.Split(" ")[1];

            //int year = int.Parse( date.Split("/")[0]);
            //int month = int.Parse( date.Split("/")[1]);
            //int dayOfMonth = int.Parse( date.Split("/")[2]);

            //int hour = int.Parse( time.Split(":")[0]);
            //int minute = int.Parse( time.Split(":")[1]);

            DateTime toDateTime = DateTime.Now;
            PersianCalendar persianCalendar = new PersianCalendar();
            string hour = persianCalendar.GetHour(fromDateTime) > 12 ? (persianCalendar.GetHour(fromDateTime) - 12 ).ToString("00") : persianCalendar.GetHour(fromDateTime).ToString("00");
            string persianFromDate = $"{persianCalendar.GetYear(fromDateTime)}/{persianCalendar.GetMonth(fromDateTime).ToString("00")}/{persianCalendar.GetDayOfMonth(fromDateTime).ToString("00")} {hour}:{persianCalendar.GetMinute(fromDateTime).ToString("00")}";
            string persianToDate = $"{persianCalendar.GetYear(toDateTime)}/{persianCalendar.GetMonth(toDateTime).ToString("00")}/{persianCalendar.GetDayOfMonth(toDateTime).ToString("00")} {hour}:{persianCalendar.GetMinute(toDateTime).ToString("00")}";
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.OpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.MemorandomDraftLoad( );
            var title=driver.FindElement( By.XPath( "//td[text()= 'درخواست تهيه گزارش ماهانه سود و زيان']" ) );
            var data=driver.FindElement( By.Id( "1" ) );
            var producedate=  driver.FindElement( By.XPath( $"//*[contains(text() ,'{persianFromDate}')]" ) );
            Assert.AreEqual( true, producedate.Displayed );
            Assert.AreEqual( true, title.Displayed );
        }
        public void SendNewMemorandom( )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 3 );
            m_ObjTo.Click( );
            m_ObjTo.SendKeys( "فر" );
            driver.FindElement( By.XPath( "//li[.='فرزانه رحيمي مسئول دفتر']" )).Click();
            m_Txtmemorandumtitle.SendKeys( "درخواست تهیه گزارش ماهانه سود و زیان" );
            driver.SwitchTo( ).Frame( m_ContentMemorandom );
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys( "لطفا گزارش ماهانه سود و زیان بابت قلم دارایی بدهی بانک مرکزی تهیه گردیده و به واحد صورت مالی تحویل داده شود.باتشکر.ی               " );
            driver.SwitchTo( ).ParentFrame( );
            DateTime fromDateTime = DateTime.Now;
            driver.FindElement( By.Id( "7f4bc636-4abb-41f1-82f9-d0ed7c036819" ) ).Click( );
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            PersianCalendar persianCalendar = new PersianCalendar();
            string hour = persianCalendar.GetHour(fromDateTime) > 12 ? (persianCalendar.GetHour(fromDateTime) - 12 ).ToString("00") : persianCalendar.GetHour(fromDateTime).ToString("00");
            string persianFromDate = $"{persianCalendar.GetYear(fromDateTime)}/{persianCalendar.GetMonth(fromDateTime).ToString("00")}/{persianCalendar.GetDayOfMonth(fromDateTime).ToString("00")} {hour}:{persianCalendar.GetMinute(fromDateTime).ToString("00")}";
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.LoadFollowupCartable( );
            IWebElement title = driver.FindElement ( By.XPath("//tr[contains(.,'درخواست تهيه گزارش ماهانه سود و زيان')]"));
            IWebElement produceDate = driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, produceDate.Displayed );
            Assert.AreEqual( true, title.Displayed );
            cartablePage.BackToShell();
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout_Succeed( );
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login_Succeed( "rahimi", "1" );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellPageLoad( );
            shellPage.OpenOfficeAutomation( );
            cartablePage.CardtableLoaded( );
            IWebElement recivememorandomtitile = driver.FindElement ( By.XPath("//tr[contains(.,'درخواست تهيه گزارش ماهانه سود و زيان')]"));
            IWebElement reciveMemorandomDate = driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual ( true, recivememorandomtitile.Displayed );
            Assert.AreEqual( true, reciveMemorandomDate.Displayed );

        }

        public void SaveAndSendNewMemorandom( )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 3 );
            m_ObjTo.Click( );
            m_ObjTo.SendKeys( "فر" );
            driver.FindElement( By.XPath( "//li[.='فرزانه رحيمي مسئول دفتر']" ) ).Click( );
            m_Txtmemorandumtitle.SendKeys( "درخواست تهیه گزارش ماهانه سود و زیان" );
            driver.SwitchTo( ).Frame( m_ContentMemorandom );
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys( "لطفا گزارش ماهانه سود و زیان بابت قلم دارایی بدهی بانک مرکزی تهیه گردیده و به واحد صورت مالی تحویل داده شود.باتشکر.ی               " );
            driver.SwitchTo( ).ParentFrame( );
            DateTime fromDateTime = DateTime.Now;
            driver.FindElement( By.Id( "f8f76661-500a-4ed5-bcd4-bd1db55c96bf-label" )).Click( );
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds( 5 );
            driver.FindElement( By.Id( "7f4bc636-4abb-41f1-82f9-d0ed7c036819" ) ).Click( );
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            PersianCalendar persianCalendar = new PersianCalendar();
            string hour = persianCalendar.GetHour(fromDateTime) > 12 ? (persianCalendar.GetHour(fromDateTime) - 12 ).ToString("00") : persianCalendar.GetHour(fromDateTime).ToString("00");
            string persianFromDate = $"{persianCalendar.GetYear(fromDateTime)}/{persianCalendar.GetMonth(fromDateTime).ToString("00")}/{persianCalendar.GetDayOfMonth(fromDateTime).ToString("00")} {hour}:{persianCalendar.GetMinute(fromDateTime).ToString("00")}";
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.LoadFollowupCartable( );
            IWebElement title = driver.FindElement ( By.XPath("//tr[contains(.,'درخواست تهيه گزارش ماهانه سود و زيان')]"));
            IWebElement produceDate = driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, produceDate.Displayed );
            Assert.AreEqual( true, title.Displayed );
            cartablePage.BackToShell( );
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout_Succeed( );
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login_Succeed( "rahimi", "1" );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellPageLoad( );
            shellPage.OpenOfficeAutomation( );
            cartablePage.CardtableLoaded( );
            IWebElement recivememorandomtitile = driver.FindElement ( By.XPath("//tr[contains(.,'درخواست تهيه گزارش ماهانه سود و زيان')]"));
            IWebElement reciveMemorandomDate = driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, recivememorandomtitile.Displayed );
            Assert.AreEqual( true, reciveMemorandomDate.Displayed );

        }

        public void MemorandomSendFromDraft( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.OpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.MemorandomDraftLoad( );
            IWebElement memorandomTitle = driver.FindElement(By.XPath("//td[text()= 'درخواست تهيه گزارش ماهانه سود و زيان']"));
            memorandomTitle.Click( );

        
        }
    }
}

    


