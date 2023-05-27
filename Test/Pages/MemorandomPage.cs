using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Network;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test.Data;
using Test.Data.Object;
using Test.Public;


namespace Test.Pages
{
    public class MemorandomPage
    {
        private IWebDriver driver;
        private  WebDriverWait webDriverWait;
        private IWebElement m_ObjTo => driver.FindElement( By.Id( "To_text" ) );
        private IWebElement m_ObjTranscriptItems0TranscriptToAsPosition => driver.FindElement( By.Id( "TranscriptItems_0_TranscriptToAsPosition_text" ) );
        private IWebElement m_ObjTranscriptItems1TranscriptToAsPosition => driver.FindElement( By.Id( "TranscriptItems_1_TranscriptToAsPosition_text" ) );
        private IWebElement m_TxtTranscriptItems0TranscriptReason => driver.FindElement( By.Id( "TranscriptItems_0__TranscriptReason" ) );
        private IWebElement m_TxtTranscriptItems1TranscriptReason1 => driver.FindElement( By.Id( "TranscriptItems_1__TranscriptReason" ) );
        private IWebElement m_BtnAdd => driver.FindElement( By.Id( "add" ) );
        private IWebElement m_ChckCopyMemorandom => driver.FindElement( By.XPath( "//div[@id='memorandum-button-wrapper']/div[1]/div[@class='table-cell']" ) );
        // private IWebElement m_ChckAdditionalData_HasTranscriptFollowUp => driver.FindElement( By.XPath( "//div[@class='icheckbox_minimal-purple checked']/ins[@class='iCheck-helper']" ));
        private IWebElement m_Txtmemorandumtitle => driver.FindElement( By.Id( "memorandum-title" ) );
        private IWebElement m_Btnimportanceflag => driver.FindElement( By.ClassName( "importance-flag" ) );
        private IWebElement m_CkEditor => driver.FindElement( By.Id( "cke_1_top" ) );
        private IWebElement m_ContentMemorandom => driver.FindElement( By.CssSelector( "#cke_1_contents > iframe" ) );
        // private IWebElement m_ContentMemorandomToolbar => driver.FindElement( By.CssSelector( "#cke_1_top > iframe" ) );

        private void SelectReciver( Memorandom memorandom )
        {
            m_ObjTo.Click( );
            m_ObjTo.SendKeys( memorandom.searchReciver );
            string[] searchResult = memorandom.searchReciverResult.Split("،" );
            foreach( string searchItem in searchResult )
                WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//li[. = '{searchItem}']" );
            driver.FindElement( By.XPath( $"//li[ .= '{memorandom.reciver}']" ) ).Click( );
        }

        private void SelectTranscript( Memorandom memorandom )
        {
            if( !string.IsNullOrEmpty( memorandom.transcriptReciver ) )
            {
                string[] searchtranscriptResult = memorandom.transcriptSearchResult.Split("،" );
                m_ObjTranscriptItems0TranscriptToAsPosition.Click( );
                m_ObjTranscriptItems0TranscriptToAsPosition.SendKeys( memorandom.transcriptSearchReciver );
                foreach( string searchItem in searchtranscriptResult )
                    WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//li[. = '{searchItem}']" );
                driver.FindElement( By.XPath( $"//li[. = '{memorandom.transcriptReciver}']" ) ).Click( );
                m_TxtTranscriptItems0TranscriptReason.SendKeys( memorandom.transcriptOrder );
            }
        }
        private void SelectTranscript2( Memorandom memorandom )
        {
            if( !string.IsNullOrEmpty( memorandom.transcriptReciver2 ) )
            {
                string[] searchtranscriptResult = memorandom.transcriptSearchResult2.Split("،" );
                driver.FindElement( By.Id( "add" ) ).Click( );
                m_ObjTranscriptItems1TranscriptToAsPosition.Click( );
                m_ObjTranscriptItems1TranscriptToAsPosition.SendKeys( memorandom.transcriptSearchReciver2 );
                // webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ) );
                foreach( string searchItem in searchtranscriptResult )
                    WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//li[. = '{searchItem}']" );
                driver.FindElement( By.XPath( $"//li[. = '{memorandom.transcriptReciver2}']" ) ).Click( );
                m_TxtTranscriptItems1TranscriptReason1.SendKeys( memorandom.transcriptOrder2 );
            }
        }

        private void SelectTranscriptReciverFromChart( Memorandom memorandom )
        {
            m_ObjTranscriptItems0TranscriptToAsPosition.Click( );
            driver.FindElement( By.XPath("//div[@class='custom-selector-icon']")).Click( );
            driver.ImplicitWaitFor( 3 );
            driver.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
            driver.FindElement( By.XPath("//div[@id='To_customSelectorContainer']"));
            driver.FindElement( By.XPath("//div[@class='header selected']")).Click( );
            driver.FindElement( By.Id("To_customSelectorContainer_Search")).SendKeys(memorandom.transcriptSearchReciver);
            IJavaScriptExecutor javaScript=(IJavaScriptExecutor) driver;
            Actions actions = new Actions(driver);
            IWebElement element = driver.FindElement( By.XPath($"//a[contains(text(),'{memorandom.transcriptSearchReciver}')]"));
               javaScript.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            driver.ImplicitWaitFor(10);
            driver.FindElement( By.XPath($"//a[contains(text(),'{memorandom.transcriptSearchReciver}')]//i[@class='jstree-icon jstree-checkbox']")).Click();
            //actions.MoveToElement(element);
            //actions.Perform();

        }

        private void SetImportance( string priority )
        {
                switch( priority )
                {
                    case "آنی":
                    driver.FindElement( By.XPath( "//span[@class='importance-flag normal']" ) ).Click( );
                    driver.FindElement( By.XPath( "//span[@class='importance-flag important']" ) ).Click( );
                    break;
                    case "فوری":
                    driver.FindElement( By.XPath( "//span[@class='importance-flag normal']" ) ).Click( );
                    break;
                }
        }

        private void SetTitle( string title )
        {
            m_Txtmemorandumtitle.SendKeys( title );
        }

        private void SetDiscription( Memorandom memorandom )
        {
                  driver.SwitchTo( ).Frame( m_ContentMemorandom );
                    IWebElement body = driver.FindElement(By.TagName("body"));
                    body.SendKeys( memorandom.discreption );
                    driver.SwitchTo( ).ParentFrame( );

            //try
            //{
            //    if( !string.IsNullOrEmpty( memorandom.readyText ) )

            //    {
            //        Actions action  = new Actions(driver);
            //        action.MoveToElement( driver.FindElement( By.XPath( "//span[@class='cke_button_icon cke_button__readytexts_icon']" ) ) ).Click().Build().Perform( );
            //        driver.FindElement( By.XPath( "//span[@class='cke_button_icon cke_button__readytexts_icon']" ) ).Click( );
            //        driver.ImplicitWaitFor( 7);
            //        driver.FindElement( By.XPath( $"//li[.='{memorandom.readyText}']" ) ).Click( );
            //        driver.ImplicitWaitFor(10);
            //    }
            //    else
            //    {
               // }
                    //driver.ImplicitWaitFor(7);
            //}
            //catch( Exception ex )
            //{

            //    throw;
            //}
        }

        private void SaveCreatedMemorandom( )
        {
            driver.FindElement( By.Id( "f8f76661-500a-4ed5-bcd4-bd1db55c96bf-label" ) ).Click( );
            driver.ImplicitWaitFor( 50 );
        }

        private void SendCreateMemorandom( )
        {
            driver.FindElement( By.Id( "7f4bc636-4abb-41f1-82f9-d0ed7c036819" ) ).Click( );
            driver.ImplicitWaitFor( 60 );
        }

        private void CheckMemorandomIsSavedInDraft( Memorandom memorandom, string persianFromDate )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.OpenSuccedMemorandomDraft( );
            MemorandomDraftPage memorandomDraftPage = new MemorandomDraftPage(driver);
            memorandomDraftPage.DraftMemorandomLoaded( );
            IWebElement title =
                driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            var producedate=
                driver.FindElement( By.XPath( $"//*[contains(text() ,'{persianFromDate}')]" ) );
            Assert.AreEqual( true, producedate.Displayed );
            Assert.AreEqual( true, title.Displayed );
        }

         private void CheckMemorandomIsSavedWithImportance( string priority)
        {
            MemorandomDraftPage memorandomDraftPage = new MemorandomDraftPage( driver );
            memorandomDraftPage.DraftMemorandomEditPageLoad( );
            if( priority == "آنی" )
            {
               Assert.AreEqual(true, driver.FindElement(By.XPath("//span[@class='importance-flag critical']")).Displayed);
            }
            else if( priority == "فوری" )
            {
                Assert.AreEqual(true, driver.FindElement(By.XPath("//span[@class='importance-flag important']")).Displayed);
            }
            else
            {
                Assert.AreEqual(true,driver.FindElement( By.XPath( "//span[@class='importance-flag normal']" )).Displayed);
            }
        }

        private void CheckMemorandomIsSavedWithTrascript( Memorandom memorandom )
        {
            MemorandomDraftPage memorandomDraftPage= new MemorandomDraftPage( driver );
            memorandomDraftPage.DraftMemorandomEditPageLoad( );
            IWebElement transcript = driver.FindElement(By.CssSelector($"[title='{memorandom.transcriptReciver}'] > .item-text"));
            IWebElement transcriptOrder = driver.FindElement(By.Id("TranscriptItems_0__TranscriptReason"));
            transcriptOrder.GetAttribute("value");
            //question
            Assert.AreEqual(true,transcript.Displayed );
          //  Assert.AreEqual( memorandom.transcriptOrder,transcriptOrder.GetAttribute("value"));
        }
        private CartablePage CheckMemorandomIsSended( Memorandom memorandom, string persianFromDate )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            //driver.ImplicitWaitFor( 7 );
            cartablePage.CartableOpenFollowUp( );
            FollowUpCartablePage followUpCartablePage = new FollowUpCartablePage(driver);
            followUpCartablePage.LoadFollowUpCartable( );
            IWebElement title =
            driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            IWebElement produceDate =
            driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, produceDate.Displayed );
            Assert.AreEqual( true, title.Displayed );
            CheckImportance( memorandom.priority );
            cartablePage.CartableBackToShell( );
            return cartablePage;
        }

        private void LoginUser( string userLogin )
        {
            UserLogin user = LoginData.FindUserByUserName(userLogin);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginSucceed( user );
        }

        private void LogoutUser( )
        {
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.LogoutSucceed( );
        }

        private void CheckImportance( string priority )
        {
            if( !string.IsNullOrEmpty( priority ) )
                Assert.AreEqual( true, driver.FindElement( By.XPath( "//tr[2]//span[@class='wil-icon itemFlag']" ) ).Displayed );
        }

        private void CheckMemorandomIsRecived( Memorandom memorandom, string persianFromDate, CartablePage cartablePage )
        {
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellLoadPage( );
            shellPage.OpenOfficeAutomation( );
            cartablePage.CartableLoaded( );
            IWebElement recivedMemorandomTitile =
            driver.FindElement ( By.XPath($"//tr[contains(.,'{memorandom.memorandomTitle}')]"));
            IWebElement recivedMemorandomDate =
            driver.FindElement ( By.XPath( $"//*[contains(text() , '{persianFromDate}')]"));
            Assert.AreEqual( true, recivedMemorandomTitile.Displayed );
            Assert.AreEqual( true, recivedMemorandomDate.Displayed );
            CheckImportance( memorandom.priority );
        }

        private void MemorandomPrepare (Memorandom memorandom )
        {
            driver.ImplicitWaitFor( 5 );
            SelectReciver( memorandom );
            SetTitle( memorandom.memorandomTitle );
            SetDiscription( memorandom );
        }
        public MemorandomPage( IWebDriver driver )
        {
            this.driver = driver;
        }

        public void MemorandomCreateLoadPage( )
        {
            IWebElement m_ObjTo =  WaitManagement.WaitForLoadAnElementById( driver , 5, "To_text" );
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
            MemorandomPrepare( memorandom );
            DateTime fromDateTime = DateTime.Now;
            SaveCreatedMemorandom( );
            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
            CheckMemorandomIsSavedInDraft( memorandom, persianFromDate );
        }

        public void MemorandomSaveWithImportance( Memorandom memorandom )
        {
            SetImportance( memorandom.priority);
            MemorandomSave( memorandom );
            CheckMemorandomIsSavedWithImportance( memorandom.priority );
        }
        
        public void MemorandomSaveWithTranscriptReciver( Memorandom memorandom )
        {
            SelectTranscript(memorandom);
            MemorandomSave( memorandom );
            CheckMemorandomIsSavedWithTrascript( memorandom );
        }

         public void MemorandomSaveWithTranscriptReciver2( Memorandom memorandom )
        {
            SelectTranscript2(memorandom);
            MemorandomSaveWithTranscriptReciver( memorandom );
            CheckMemorandomIsSavedWithTrascript( memorandom );
        }

        public void MemorandomSaveSelectTranscriptFromChart( Memorandom memorandom )
        {
            SelectTranscriptReciverFromChart( memorandom );
        }

        public void MemorandomSend( Memorandom memorandom )
        {
            MemorandomPrepare( memorandom );
            DateTime fromDateTime = DateTime.Now;
            SendCreateMemorandom( );

            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
            CartablePage cartablePage = CheckMemorandomIsSended( memorandom, persianFromDate );
            LogoutUser( );
            LoginUser( memorandom.userLogin );
            CheckMemorandomIsRecived( memorandom, persianFromDate, cartablePage );
        }

        public void SaveAndSendNewMemorandom( Memorandom memorandom )
        {
            driver.ImplicitWaitFor( 5 );
            SelectReciver( memorandom );
            SelectTranscript( memorandom );
            SelectTranscript2( memorandom );
            SetImportance( memorandom.priority );
            SetTitle( memorandom.memorandomTitle );
            SetDiscription( memorandom );
            DateTime fromDateTime = DateTime.Now;
            SaveCreatedMemorandom( );

            SendCreateMemorandom( );

            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
            CartablePage cartablePage = CheckMemorandomIsSended( memorandom, persianFromDate );
            LogoutUser( );
            LoginUser( memorandom.userLogin );
            CheckMemorandomIsRecived( memorandom, persianFromDate, cartablePage );
        }

    }
}




