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
using Test.Data;

namespace Test.Pages
{
    public class MemorandomPage
    {
        private IWebDriver driver;
        private  WebDriverWait webDriverWait;
        private IWebElement m_ObjTo                                     => driver.FindElement( By.Id( "To_text" ) );
        private IWebElement m_ObjTranscriptItems0TranscriptToAsPosition => driver.FindElement( By.Id( "TranscriptItems_0_TranscriptToAsPosition_text" ) );
        private IWebElement m_TxtTranscriptItems0TranscriptReason       => driver.FindElement( By.Id( "TranscriptItems_0__TranscriptReason" ) );
        private IWebElement m_BtnAdd                                    => driver.FindElement( By.Id( "add" ) );
        private IWebElement m_ChckCopyMemorandom                        => driver.FindElement( By.XPath( "//div[@id='memorandum-button-wrapper']/div[1]/div[@class='table-cell']" ) );
        // private IWebElement m_ChckAdditionalData_HasTranscriptFollowUp => driver.FindElement( By.XPath( "//div[@class='icheckbox_minimal-purple checked']/ins[@class='iCheck-helper']" ));
        private IWebElement m_Txtmemorandumtitle                        => driver.FindElement( By.Id( "memorandum-title" ) );
        private IWebElement m_Btnimportanceflag                         => driver.FindElement( By.ClassName( "importance-flag" ) );
        private IWebElement m_CkEditor                                  => driver.FindElement( By.Id( "cke_1_top" ) );
        private IWebElement m_ContentMemorandom                         => driver.FindElement( By.CssSelector( "#cke_1_contents > iframe" ) );
        public MemorandomPage( IWebDriver driver )
        {
            this.driver = driver;
        }

        public void MemorandomCreateLoadPage( )
        {
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ));
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

        public void MemorandomSave( Memorandom memorandom )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            //search and selected reciver
            m_ObjTo.Click( );
            m_ObjTo.SendKeys( memorandom.searchReciver);
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ));
            string[] searchResult = memorandom.searchReciverResult.Split("،" );
            foreach( string searchItem in searchResult )
                webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.XPath( $"//li[. = '{searchItem}']"))); 
            driver.FindElement( By.XPath( $"//li[ .= '{memorandom.reciver}']" )).Click( );
            if(memorandom.transcriptReciver is not null )
            {

             string[] searchtranscriptResult = memorandom.transcriptSearchResult.Split("،" );
             m_ObjTranscriptItems0TranscriptToAsPosition.Click();
             m_ObjTranscriptItems0TranscriptToAsPosition.SendKeys( memorandom.transcriptSearchReciver);
             webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ));
             foreach( string searchItem in searchtranscriptResult )
                {

                 webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.XPath($"//li[. = '{searchItem}']"))); 
                   
                }
             driver.FindElement( By.XPath($"//li[. = '{memorandom.transcriptReciver}']")).Click(); 
             m_TxtTranscriptItems0TranscriptReason.SendKeys(memorandom.transcriptOrder) ;
            }
            //title
            m_Txtmemorandumtitle.SendKeys( memorandom.memorandomTitle );
            //discreption
            driver.SwitchTo( ).Frame( m_ContentMemorandom );
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys( memorandom.discreption);
            driver.SwitchTo( ).ParentFrame( );
            //save
            DateTime fromDateTime = DateTime.Now;
            driver.FindElement( By.Id( "f8f76661-500a-4ed5-bcd4-bd1db55c96bf-label" ) ).Click( );
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            //findcreatememorandomdate
            DateTime toDateTime = DateTime.Now;
            PersianCalendar persianCalendar = new PersianCalendar();
            string hour =
                persianCalendar.GetHour(fromDateTime) > 12 ? (persianCalendar.GetHour(fromDateTime) - 12 ).ToString("00") : persianCalendar.GetHour(fromDateTime).ToString("00");
            string persianFromDate =
                $"{persianCalendar.GetYear(fromDateTime)}/{persianCalendar.GetMonth(fromDateTime).ToString("00")}" +
                $"/{persianCalendar.GetDayOfMonth(fromDateTime).ToString("00")}" +
                $" {hour}:{persianCalendar.GetMinute(fromDateTime).ToString("00")}";
            string persianToDate =
                $"{persianCalendar.GetYear(toDateTime)}/{persianCalendar.GetMonth(toDateTime).ToString("00")}" +
                $"/{persianCalendar.GetDayOfMonth(toDateTime).ToString("00")}" +
                $" {hour}:{persianCalendar.GetMinute(toDateTime).ToString("00")}";
            //check  memorandom create in draft correctly
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.OpenSuccedMemorandomDraft( );
            MemorandomDraftPage memorandomDraftPage = new MemorandomDraftPage(driver);
            memorandomDraftPage.DraftMemorandomLoaded();
            IWebElement title =
                driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            var producedate=
                driver.FindElement( By.XPath( $"//*[contains(text() ,'{persianFromDate}')]" ) );
            Assert.AreEqual( true, producedate.Displayed );
            Assert.AreEqual( true, title.Displayed );
        }
        public void MemorandomSend( Memorandom memorandom )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            m_ObjTo.Click( );
            m_ObjTo.SendKeys( memorandom.searchReciver );
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ));
            string[] searchResult = memorandom.searchReciverResult.Split("،" );
            foreach( string searchItem in searchResult )
               webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.XPath( $"//li[. = '{searchItem}']"))); 
            driver.FindElement( By.XPath( $"//li[ .= '{memorandom.reciver}']" )).Click( );
            //title
            m_Txtmemorandumtitle.SendKeys( memorandom.memorandomTitle );
            //discreption
            driver.SwitchTo( ).Frame( m_ContentMemorandom );
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys( memorandom.discreption);
            driver.SwitchTo( ).ParentFrame( );
            //send
            DateTime fromDateTime = DateTime.Now;
            driver.FindElement( By.Id( "7f4bc636-4abb-41f1-82f9-d0ed7c036819" )).Click( );
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            PersianCalendar persianCalendar = new PersianCalendar();
            string hour =
                persianCalendar.GetHour( fromDateTime ) > 12 ? (persianCalendar.GetHour( fromDateTime ) - 12 ).ToString( "00" ) :
                persianCalendar.GetHour(fromDateTime).ToString("00");
                string persianFromDate =
                $"{persianCalendar.GetYear(fromDateTime)}" +
                $"/{persianCalendar.GetMonth(fromDateTime).ToString("00")}" +
                $"/{persianCalendar.GetDayOfMonth(fromDateTime).ToString("00")} " +
                $"{hour}:{persianCalendar.GetMinute(fromDateTime).ToString("00")}";
            //check memorandom send correctly
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded();
            cartablePage.CartableOpenFollowUp( );
            FollowUpCartablePage followUpCartablePage = new FollowUpCartablePage(driver);
            followUpCartablePage.LoadFollowUpCartable( );
            IWebElement title =
                driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            IWebElement produceDate =
                driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, produceDate.Displayed );
            Assert.AreEqual( true, title.Displayed );
            cartablePage.CartableBackToShell();
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.LogoutSucceed( );
            UserLogin user = LoginData.FindUserByUserName(memorandom.userLogin);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginSucceed( user );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellLoadPage( );
            shellPage.OpenOfficeAutomation( );
            cartablePage.CartableLoaded( );
            IWebElement recivedMemorandomTitile =
                driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            IWebElement recivedMemorandomDate =
                driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual ( true, recivedMemorandomTitile.Displayed );
            Assert.AreEqual( true, recivedMemorandomDate.Displayed );

        }

        public void SaveAndSendNewMemorandom( Memorandom memorandom )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 7 );
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ));
            //search and select memorandom
            m_ObjTo.Click( );
            m_ObjTo.SendKeys( memorandom.searchReciver);
            //check reciver is in Workflow rules
             webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ));
            string[] searchResult = memorandom.searchReciverResult.Split("،" );
            foreach( string searchItem in searchResult )
               webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.XPath( $"//li[. = '{searchItem}']")));
            driver.FindElement( By.XPath( $"//li[.='{memorandom.reciver}']" ) ).Click( );
            //title and description
            m_Txtmemorandumtitle.SendKeys(memorandom.memorandomTitle );
            driver.SwitchTo( ).Frame( m_ContentMemorandom );
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys( memorandom.discreption );
            driver.SwitchTo( ).ParentFrame( );
            DateTime fromDateTime = DateTime.Now;
            driver.FindElement( By.Id( "f8f76661-500a-4ed5-bcd4-bd1db55c96bf-label" )).Click( );//save
            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds( 5 );
            webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.Id(  "7f4bc636-4abb-41f1-82f9-d0ed7c036819" ))).Click();
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            PersianCalendar persianCalendar = new PersianCalendar();
            string hour =
                persianCalendar.GetHour(fromDateTime) > 12 ? (persianCalendar.GetHour(fromDateTime) - 12 ).ToString("00")
                : persianCalendar.GetHour(fromDateTime).ToString("00");
            string persianFromDate =
                $"{persianCalendar.GetYear(fromDateTime)}" +
                $"/{persianCalendar.GetMonth(fromDateTime).ToString("00")}" +
                $"/{persianCalendar.GetDayOfMonth(fromDateTime).ToString("00")}" +
                $" {hour}:{persianCalendar.GetMinute(fromDateTime).ToString("00")}";
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenFollowUp( );
            FollowUpCartablePage followUpCartablePage = new FollowUpCartablePage(driver);
            followUpCartablePage.LoadFollowUpCartable();
            IWebElement title =
                driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            IWebElement produceDate
                = driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, produceDate.Displayed );
            Assert.AreEqual( true, title.Displayed );
            cartablePage.CartableBackToShell( );
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.LogoutSucceed( );
            LoginPage loginPage = new LoginPage(driver);
            UserLogin user = LoginData.FindUserByUserName(memorandom.userLogin);
            loginPage.LoginSucceed( user );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellLoadPage( );
            shellPage.OpenOfficeAutomation( );
            cartablePage.CartableLoaded( );
            IWebElement recivememorandomtitile =
                driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            IWebElement reciveMemorandomDate =
                driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, recivememorandomtitile.Displayed );
            Assert.AreEqual( true, reciveMemorandomDate.Displayed );

        }

       
    }
}

    


