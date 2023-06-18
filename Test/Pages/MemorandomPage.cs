using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Threading;
using Test.Data;
using Test.Data.Objects;
using Test.Public;




namespace Test.Pages
{
    public class MemorandomPage
    {
        private IWebDriver driver;
        private  WebDriverWait webDriverWait;
        private IWebElement m_ObjTo => driver.FindElement( By.XPath( "//div[@class='items-container']//*[@id='To_text']" ));
        private IWebElement m_ObjToselect => driver.FindElement( By.CssSelector( "#To_objectPicker .items-container" ));
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
        #region SelectMemorandomProperties
        private void SelectReciver( ObjectPiker reciver )
        {
            try
                {
            driver.ImplicitWaitFor( 3);
             driver.FindElement( By.CssSelector( "#To_objectPicker .items-container" )).Click( );
           // m_ObjToselect.Click( );
            driver.ImplicitWaitFor( 3);
            m_ObjTo.SendKeys( reciver.searchReciver );
            string[] searchResult = reciver.searchReciverResult.Split("،" );
            foreach( string searchItem in searchResult )
                WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//li[. = '{searchItem}']" );
            driver.FindElement( By.XPath( $"//li[ .= '{reciver.reciver}']" ) ).Click( );
            }
            catch(Exception exp )
            {
                throw;

            }
        }

        private void SelectTranscript( ObjectPiker reciver )
        {
                string[] searchtranscriptResult = reciver.transcriptSearchResult.Split("،" );
                m_ObjTranscriptItems0TranscriptToAsPosition.Click( );
                m_ObjTranscriptItems0TranscriptToAsPosition.SendKeys( reciver.transcriptSearchReciver );
                foreach( string searchItem in searchtranscriptResult )
                    WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//li[. = '{searchItem}']" );
                driver.FindElement( By.XPath( $"//li[. = '{reciver.transcriptReciver}']" ) ).Click( );
                m_TxtTranscriptItems0TranscriptReason.SendKeys( reciver.transcriptOrder );
            
        }

         private void SelectTranscriptWithReferralOrder( ObjectPiker reciver , string referralCommand )
        {
                string[] searchtranscriptResult = reciver.transcriptSearchResult.Split("،" );
                m_ObjTranscriptItems0TranscriptToAsPosition.Click( );
                m_ObjTranscriptItems0TranscriptToAsPosition.SendKeys( reciver.transcriptSearchReciver );
                foreach( string searchItem in searchtranscriptResult )
                    WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//li[. = '{searchItem}']");
                driver.FindElement( By.XPath( $"//li[. = '{reciver.transcriptReciver}']" ) ).Click( );
                new Actions( driver ).DoubleClick( driver.FindElement( By.XPath( "//input[@id='TranscriptItems_0__TranscriptReason']" ))).Build( ).Perform( );
                driver.ImplicitWaitFor( 3 );
                driver.FindElement ( By.XPath($"//a[text(),'{referralCommand}']")).Click( );
            
        }

        private void SelectTranscript2( ObjectPiker  reiver )
        {
                string[] searchtranscriptResult = reiver.searchResultTranscriptReciver2.Split("،" );
                driver.FindElement( By.Id( "add" ) ).Click( );
                m_ObjTranscriptItems1TranscriptToAsPosition.Click( );
                m_ObjTranscriptItems1TranscriptToAsPosition.SendKeys( reiver.searchTranscriptReciver2 );
                foreach( string searchItem in searchtranscriptResult )
                    WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//li[. = '{searchItem}']" );
                driver.FindElement( By.XPath( $"//li[. = '{reiver.transcriptReciver2}']" ) ).Click( );
                m_TxtTranscriptItems1TranscriptReason1.SendKeys( reiver.transcriptOrder2 );
        }

        private void SelectReciverFromChart( ObjectPiker reciver )
        {
            string[] searchresult = reciver.searchResultReciverFromChart.Split("،");
            
            driver.FindElement( By.XPath("//div[@class='custom-selector-icon']")).Click( );
            driver.ImplicitWaitFor( 3 );
            driver.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
            driver.FindElement( By.XPath("//div[@id='To_customSelectorContainer']"));
            driver.FindElement( By.XPath("//div[contains(text(),'نمایش چارت')]")).Click( );
            driver.FindElement( By.Id("To_customSelectorContainer_Search")).SendKeys(reciver.searchReciverFromChart );
            foreach( string searchItem in searchresult )
            {
                IJavaScriptExecutor javaScriptc=(IJavaScriptExecutor) driver; 
                 IWebElement element1= WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//a[@class='jstree-anchor jstree-search'][contains(text(),'{searchItem}')]" );
                 javaScriptc.ExecuteScript("arguments[0].scrollIntoView();", element1);
            }
            IJavaScriptExecutor javaScript=(IJavaScriptExecutor) driver;
            IWebElement element = driver.FindElement( By.XPath($"//a[contains(text(),'{reciver.reciverFromChart}')]"));
            javaScript.ExecuteScript("arguments[0].scrollIntoView();", element);
            driver.ImplicitWaitFor(2);
            driver.FindElement( By.XPath($"//a[contains(text(),'{reciver.reciverFromChart}')]//i[@class='jstree-icon jstree-checkbox']")).Click();
            driver.FindElement(By.Id("To_objectPicker")).Click( );
        }

         private void SelectReciverFromPersonelList( ObjectPiker reciver )
        {
            driver.FindElement( By.XPath("//div[@class='custom-selector-icon']")).Click( );
            driver.ImplicitWaitFor( 3 );
            driver.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
            driver.FindElement( By.XPath("//div[@id='To_customSelectorContainer']"));
            driver.FindElement( By.XPath("//div[@class='header selected'][contains(text(),'لیست شخصی')]")).Click( );
            driver.FindElement( By.XPath("//div[@class='favorite-list']")).Click( );
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='To_customSelectorContainer']//div[@class='favoriteItem table fixed']"));
            string [] PersonelListItem = reciver.searchResultReciverFromPersonelList.Split( "،" );
            foreach(string searchItem in PersonelListItem )
            {
                driver.FindElement( By.XPath( $"//div[@id='To_customSelectorContainer']//a[text()='{searchItem}']"));
            }
            driver.FindElement( By.XPath($"//div[@text='{reciver.reciverFromPersonelList}']")).Click( );
            driver.FindElement(By.Id("To_objectPicker")).Click( );
        }

         private void SelectTranscriptReciverFromChart( ObjectPiker reciver )
        {
            string[] searchresult = reciver.searchResultTranscriptReciverFromChart.Split("،");
            driver.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']//div[@class='custom-selector-icon']")).Click( );
            driver.ImplicitWaitFor( 3 );
            driver.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
            driver.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//div[contains(text(),'نمایش چارت')]")).Click( );
            driver.FindElement( By.Id("TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer_Search")).SendKeys(reciver.searchTranscriptReciverFromChart );
            foreach( string searchItem in searchresult )
            {
                IJavaScriptExecutor javaScriptc=(IJavaScriptExecutor) driver; 
                 IWebElement element1= WaitManagement.WaitForLoadAnElementByXPath( driver, 5, $"//a[@class='jstree-anchor jstree-search'][contains(text(),'{searchItem}')]" );
                 javaScriptc.ExecuteScript("arguments[0].scrollIntoView();", element1);
            }
            IJavaScriptExecutor javaScript=(IJavaScriptExecutor) driver;
            IWebElement element = driver.FindElement( By.XPath($"//a[contains(text(),'{reciver.transcriptReciverFromChart}')]"));
            javaScript.ExecuteScript("arguments[0].scrollIntoView();", element);
            driver.ImplicitWaitFor(2);
            driver.FindElement( By.XPath($"//a[@class='jstree-anchor jstree-search'][contains(text(),'{reciver.transcriptReciverFromChart}')]")).Click();
             driver.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']")).Click( );
            //driver.FindElement( By.Id("TranscriptItems_0_TranscriptToAsPosition_objectPicker")).Click( );
            //IWebElement closeCustomer = driver.FindElement( By.XPath("//[@class='custom-selector-closer']"));
            //Assert.AreEqual(true , closeCustomer.Displayed);
        }

         private void SelectTranscriptReciverFromPersonelList(ObjectPiker reciver )
        {
            string[] searchresult = reciver.searchResultTranscriptReciverFromPersonelList.Split("،");
            ReadOnlyCollection<IWebElement> reciversSelected = driver.FindElements( By.XPath("//div[@id='To_objectPicker']//span[@class='item']"));
            driver.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']//div[@class='custom-selector-icon']")).Click( );
            driver.ImplicitWaitFor( 3 );
            driver.FindElement( By.XPath("//div[@class='custom-selector-closer shown']"));
            driver.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//div[contains(text(),'لیست شخصی')]")).Click( );
            ReadOnlyCollection<IWebElement> elements = driver.FindElements( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//div[@class='favoriteItem table fixed']"));
            foreach( string searchItem in searchresult )
                driver.FindElement( By.XPath( $"//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//a[text()='{searchItem}']"));
            driver.FindElement( By.XPath($"//div[@id='TranscriptItems_0_TranscriptToAsPosition_customSelectorContainer']//a[text()='{reciver.transcriptReciverFromPersonelList}']")).Click( );
            driver.FindElement( By.XPath("//div[@id='TranscriptItems_0_TranscriptToAsPosition_objectPicker']")).Click( );

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
            if( string.IsNullOrEmpty(body.Text ) )
            {
                 body.SendKeys( memorandom.discreption );
                 
                 Assert.AreEqual(true,body.Displayed);
            }
            driver.SwitchTo( ).ParentFrame( );
        }
        private void SetMemorandomDiscriptionWithPrepareContent( ReadyText readyText )
        {
            Actions action  = new Actions(driver);
            driver.FindElement( By.XPath( "//span[@class='cke_button_icon cke_button__readytexts_icon']" )).Click( );
            driver.FindElement( By.XPath( "//span[@class='cke_button_icon cke_button__readytexts_icon']" )).Click( );
            driver.ImplicitWaitFor( 1 );
            driver.FindElement( By.XPath( $"//li[.='{readyText.readyTextTitle}']" )).Click( );
            IWebElement pop= driver.FindElement( By.CssSelector("#popup-container-closer"));
            pop.Click();
            driver.SwitchTo( ).Frame( m_ContentMemorandom );
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.AreEqual( readyText.readyTextDiscription,body.Text );
            driver.SwitchTo( ).ParentFrame( );
        }

        private void SelectMemorandomAttachment( string fileName )
        {
            IWebElement fileUploadContent = driver.FindElement( By.Id( "3fa525f9-4419-47bd-8bc2-f8c4166450b7" ));
            fileUploadContent.Click();
            driver.ImplicitWaitFor( 2 );
            HandleOpenDialog hndOpen = new HandleOpenDialog();  
            hndOpen.fileOpenDialog(@"E:\FileUpload\MemorandomAttachment", fileName); 
            IWebElement attachmentsUploaded = driver.WaitForLoadAnElementByXPath( 3 , "//div[@class='attachment-containter']");
            Assert.That( attachmentsUploaded.Displayed ,Is.EqualTo( true ));
        }
        #endregion

        #region MemorandomMethod
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
        
        private void MemorandomPrepare (Memorandom memorandom , ObjectPiker reciver )
        {
            SetDiscription( memorandom );
            SetTitle( memorandom.memorandomTitle );
            SelectReciver( reciver );
        }

        #endregion

        private void LogoutUser( )
        {
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.LogoutSucceed( );
        }
        private void LoginUser( string userLogin )
        {
            UserLogin user = LoginData.FindUserByUserName(userLogin);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginSucceed( user );
        }

        #region CheckMemorandomAction
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

        private void CheckMemorandomIsSavedWithTrascript( ObjectPiker reciver )
        {
            MemorandomDraftPage memorandomDraftPage= new MemorandomDraftPage( driver );
            memorandomDraftPage.DraftMemorandomEditPageLoad( );
            IWebElement transcript = driver.FindElement(By.CssSelector($"[title='{reciver.transcriptReciver}'] > .item-text"));
            IWebElement transcriptOrder = driver.FindElement(By.Id("TranscriptItems_0__TranscriptReason"));
            transcriptOrder.GetAttribute("value");
            //question
            Assert.AreEqual(true,transcript.Displayed );
          //  Assert.AreEqual( memorandom.transcriptOrder,transcriptOrder.GetAttribute("value"));
        }

         private void CheckMemorandomIsSavedWithTrascriptReciver2( ObjectPiker reciver )
        {
            IWebElement transcriptReciver2 = driver.FindElement(By.CssSelector($"[title='{reciver.transcriptReciver2}'] > .item-text"));
            IWebElement transcriptOrder2 = driver.FindElement(By.Id("TranscriptItems_1__TranscriptReason"));
            transcriptOrder2.GetAttribute("value");
            //question
            Assert.AreEqual(true,transcriptReciver2.Displayed );
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

        private void CheckMemorandomIsSavedWithAttachment( Memorandom memorandom ,ObjectPiker objectPiker )
        {
            MemorandomDraftPage memorandomDraftPage = new MemorandomDraftPage(driver);
             memorandomDraftPage.DraftMemorandomShowPageLoad( memorandom , objectPiker );
        }

        #endregion

        public MemorandomPage( IWebDriver driver )
        {
            this.driver = driver;
        }

        public void MemorandomCreateLoadPage( )
        {
            driver.ImplicitWaitFor( 5 );
            IWebElement m_ObjTo =  WaitManagement.WaitForLoadAnElementById( driver , 7, "To_text" );
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
        
        public void MemorandomSave( Memorandom memorandom , ObjectPiker reciver )
        {
            //driver.ImplicitWaitFor( 5 );
            MemorandomPrepare( memorandom , reciver );
            DateTime fromDateTime = DateTime.Now;
            SaveCreatedMemorandom( );
            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
            CheckMemorandomIsSavedInDraft( memorandom, persianFromDate );
        }

        public void MemorandomSaveWithImportance( Memorandom memorandom , ObjectPiker reciver )
        {
            SetImportance( memorandom.priority);
            MemorandomSave( memorandom , reciver );
            CheckMemorandomIsSavedWithImportance( memorandom.priority );
        }
        
        public void MemorandomSaveWithTranscriptReciver( Memorandom memorandom , ObjectPiker reciver)
        {
            SelectTranscript(reciver);
            MemorandomSave( memorandom , reciver );
            CheckMemorandomIsSavedWithTrascript( reciver );
        }

        public void MemorandomSaveWithTranscriptReciver2( Memorandom memorandom , ObjectPiker reciver )
        {
            SelectTranscript2(reciver);
            MemorandomSaveWithTranscriptReciver(  memorandom , reciver );
            CheckMemorandomIsSavedWithTrascriptReciver2( reciver );
        }

        public void MemorandomSaveSelectReciversFromChartAndPersonalList( Memorandom memorandom, ObjectPiker reciver)
        {
            SelectReciverFromChart(  reciver );
            SelectReciverFromPersonelList( reciver );
            SelectTranscriptReciverFromChart( reciver );
            SelectTranscriptReciverFromPersonelList( reciver );
            MemorandomSave( memorandom , reciver );
       
        }
        public void MemorandomSavewithPrepareContent( Memorandom memorandom , ReadyText readyText , ObjectPiker objectPiker )
        {
            //driver.ImplicitWaitFor( 7 );
            SetMemorandomDiscriptionWithPrepareContent( readyText );
            MemorandomSave( memorandom , objectPiker );
        }
        
        public void MemorandomSaveWithTranscriptOrderFromReferralCommand( Memorandom memorandom , ObjectPiker objectPiker , string referralCommand )
        {
            //driver.ImplicitWaitFor( 7 );
            SelectTranscriptWithReferralOrder( objectPiker , referralCommand );
            MemorandomSave( memorandom , objectPiker );
        }

        public void MemorandomSaveSelectMemorandomAttachment( Memorandom memorandom, ObjectPiker objectPiker )
        {
            driver.ImplicitWaitFor(5);
            SelectMemorandomAttachment( memorandom.fileAttachmentName );
            MemorandomSave( memorandom, objectPiker );
            CheckMemorandomIsSavedWithAttachment( memorandom , objectPiker );
        }

        public void MemorandomSend( Memorandom memorandom , ObjectPiker reciver )
        {
            MemorandomPrepare( memorandom , reciver );
            DateTime fromDateTime = DateTime.Now;
            SendCreateMemorandom( );
            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
            CartablePage cartablePage = CheckMemorandomIsSended( memorandom, persianFromDate );
            LogoutUser( );
            //LoginUser( memorandom.userLogin );
            CheckMemorandomIsRecived( memorandom, persianFromDate, cartablePage );
        }

        public void SaveAndSendNewMemorandom( Memorandom memorandom , ObjectPiker reciver)
        {
            driver.ImplicitWaitFor( 5 );
            SelectReciver( reciver );
            SelectTranscript( reciver );
            SelectTranscript2( reciver );
            SetImportance( memorandom.priority );
            SetTitle( memorandom.memorandomTitle );
            SetDiscription( memorandom );
            DateTime fromDateTime = DateTime.Now;
            SaveCreatedMemorandom( );

            SendCreateMemorandom( );

            string persianFromDate=Utility.ConvertDateToPersianDate(fromDateTime);
            CartablePage cartablePage = CheckMemorandomIsSended( memorandom, persianFromDate );
            LogoutUser( );
            //LoginUser( memorandom.userLogin );
            CheckMemorandomIsRecived( memorandom, persianFromDate, cartablePage );
        }

    }
}




