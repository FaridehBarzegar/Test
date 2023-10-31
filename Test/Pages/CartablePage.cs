using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{

	public static class CartablePage
    {
        private static IWebElement m_BtnNewForm => Driver.Instance.FindElement( By.Id( "43fa13dd-cb8f-4daf-be7a-c3712435c10b" ) );
        private static IWebElement m_BtnbeingProcessingCartable => Driver.Instance.FindElement( By.PartialLinkText( "در دست اقدام" ) );
        private static IWebElement m_Btnexpandservices => Driver.Instance.FindElement( By.Id( "expand-services" ) );
        private static IWebElement m_BtnBackToShell => Driver.Instance.FindElement( By.CssSelector( "[alt='ليست برنامه‌ها']" ) );

        internal static void VerifyLoadCartable( )
        {
            Driver.Instance.ImplicitWaitFor("Load Cartable");
            IWebElement  listEntityInCartable = Driver.Instance.WaitForLoadAnElementById("WIL-list" ,"list Entity In Cartable");
            IWebElement  commands             = Driver.Instance.FindElement(By.Id("commands"));
            IWebElement  btnNewOutgoingLetter = Driver.Instance.FindElement(By.Id("2bc68c0a-45b6-445d-910f-0813389ba951-label"));
            IWebElement  btnNewMemorandom     = Driver.Instance.FindElement(By.Id("38153e8e-0e5e-4ad8-bc84-fa9e810023d2-label"));
            IWebElement  btnNewInternalLetter = Driver.Instance.FindElement(By.Id("e6b0b89c-f8b3-40ca-8c13-935a9032c662-label"));
            IWebElement  btnNewForm           = Driver.Instance.FindElement(By.Id("43fa13dd-cb8f-4daf-be7a-c3712435c10b-label"));
            IWebElement  btnRefresh           = Driver.Instance.FindElement(By.Id("7d7b23e0-7b19-4e61-a50b-44c3ac6a6d74-label"));
            IWebElement  btnFollowUpCartable  = Driver.Instance.FindElement(By.XPath( "//a[@data-title='پیگیری ها']"));
            // Assert.That( m_BtnInboxCartable.Text , Is.EqualTo( "جاری" ) );
            ErrorDetector.Detect();
            Assert.That( commands.Displayed , Is.EqualTo( true ) );
            Assert.That( listEntityInCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( btnFollowUpCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( m_BtnbeingProcessingCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( btnNewOutgoingLetter.Text , Is.EqualTo( "نامه صادره جدید" ) , "shown" );
            Assert.That( btnNewInternalLetter.Text , Is.EqualTo( "نامه داخلی جدید" ) , "shown" );
            Assert.That( btnNewMemorandom.Text , Is.EqualTo( "یادداشت اداری جدید" ) , "shown" );
            Assert.That( btnNewForm.Text , Is.EqualTo( "فرم جدید" ) );
            Assert.That( btnRefresh.Text , Is.EqualTo( "به روز رسانی" ) );
            Assert.That( m_BtnBackToShell.Displayed , Is.EqualTo( true ) );
            Assert.That( m_Btnexpandservices.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnInboxPanel( )
        {
            IWebElement btnInboxCartable = Driver.Instance.WaitForLoadAnElementByXPath( "//a[@data-title='جاری']" , "InboxCartable" );
            btnInboxCartable.Click();
            Driver.Instance.ImplicitWaitFor( "Inbox Cartable" );
        }

        internal static void EnsureMemorandomIsRecived( string memorandomTitle )
        {
            DateTime fromDateTime = DateTime.Now;
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            IWebElement recivedMemorandomTitile =
            Driver.Instance.FindElement( By.XPath( $"//tr[contains(.,'{memorandomTitle}')]" ) );
            IWebElement recivedMemorandomDate =
            Driver.Instance.FindElement( By.XPath( $"//*[contains(text() , '{persianFromDate}')]" ) );
            ErrorDetector.Detect();
            Assert.That( recivedMemorandomTitile.Displayed , Is.EqualTo( true ) );
            Assert.That( recivedMemorandomDate.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnFollowUpPanel( )
        {
            IWebElement btnFollowUpCartable = Driver.Instance.WaitForLoadAnElementByXPath( "//a[@data-title='پیگیری ها']" , "followUpPanel" );
            btnFollowUpCartable.Click();
            Driver.Instance.ImplicitWaitFor( "FollowUp Cartable" );
        }

        internal static void BackToShell( )
        {
            Driver.Instance.ImplicitWaitFor( "back to Shell Icon" );
            IWebElement btnBackToShell = Driver.Instance.FindElement(By.Id("signout-icon"));
            btnBackToShell.Click();
        }

        internal static void ClickOnNewMemorandomCommand( )
        {
            Driver.Instance.WaitForLoadAnElementById("38153e8e-0e5e-4ad8-bc84-fa9e810023d2-label","New Memoranom").Click();
            Driver.Instance.ImplicitWaitFor("Load Memorandom Page");
        }

        internal static void OpenServices( )
        {
            m_Btnexpandservices.Click();
        }

        internal static void ClickOnDraftPanel( )
        {

            IWebElement lnkdraftPanel = Driver.Instance.WaitForLoadAnElementById( "draft-link" , "draftPanel" );
            lnkdraftPanel.Click();
        }

        internal static void OpenFormList( )
        {
            m_BtnNewForm.Click();
            Driver.Instance.ImplicitWaitFor( "FormList" );
        }

        internal static void ClickOnKarkonanFormFromFormsList( )
        {
            Driver.Instance.FindElement( By.LinkText( "اطلاعات پرسنل" ) ).Click();
            //   Driver.Instance.ImplicitWaitFor( "CreationEFomPage" );
        }

        internal static void VerifyKarkonanFormReciveInCartable( Form Form )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime toDateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianToDateTime = Utility.ConvertDateToPersianDate(toDateTime);
            IWebElement recivedFormTitle =
            Driver.Instance.FindElement( By.XPath( $"//tr[contains(.,'{Form.FormTitle}')]" ) );
            IWebElement recivedFormDate =
            Driver.Instance.FindElement( By.XPath( $"//*[contains(text() , '{persianFromDate}') or contains(text() , '{persianToDateTime}')]" ) );
            ErrorDetector.Detect();
            Assert.That( recivedFormTitle.Displayed , Is.EqualTo( true ) );
            Assert.That( recivedFormDate.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnForm( Form Form )
        {
            Driver.Instance.FindElement( By.XPath( $"//tr[contains(.,'{Form.FormTitle}')]" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "FEormCommand" );
        }

        internal static void VerifyFormCommandIsLoadCorrectly( )
        {
            IWebElement commandNew = Driver.Instance.FindElement(By.Id("creation-commands-dropdown-label"));
            IWebElement commandRefer = Driver.Instance.FindElement(By.Id("3db38e7f-ffc2-4219-aaeb-995ca892c3a8-label"));
            IWebElement commandTag = Driver.Instance.FindElement(By.Id("78354bec-04cd-4cc0-b535-a84c52390450-label"));
            IWebElement commandRemoveFromWorkspace = Driver.Instance.FindElement(By.Id("d600ff1f-86ee-4ada-b14a-ee86e8bfcfa8-label"));
            IWebElement commandFormAccept = Driver.Instance.FindElement(By.Id("990a3e70-73d5-4baa-b75f-7e6825acc4a8-label"));
            IWebElement commandFormCollectiveAccept = Driver.Instance.FindElement(By.Id("38bb3f87-a870-45e7-8af7-08ab6ca90b62-label"));
            IWebElement commandEntityArchive = Driver.Instance.FindElement(By.Id("2c990639-cbaa-4ec6-bb63-576e56941f0f-label"));
            IWebElement commandWorkTransactionCycle = Driver.Instance.FindElement(By.Id("85b37846-1f3e-4cb7-ae98-00a21113366b-label"));
            IWebElement commandActions = Driver.Instance.FindElement(By.Id("586fe5b6-a73e-4ef5-934d-c15b26b4d84b-label"));
            IWebElement commandCreateRelatedForm = Driver.Instance.FindElement(By.Id("f709054b-5a52-443c-9f83-132c643f4a02-label"));
            IWebElement commandWorkTransactionMoveToBeingProcessing = Driver.Instance.FindElement(By.Id("328a80ac-fb90-46f9-ad97-7f6ef0e4a9e5-label"));
            IWebElement commandFurtherInformation = Driver.Instance.FindElement(By.Id("1e3d2951-7cef-4385-b5a1-6c412a5a670c-label"));
            IWebElement morecommands = Driver.Instance.FindElement(By.Id("more-commands"));
            Driver.Instance.FindElement( By.Id( "more-commands" ) ).Click();
            IWebElement commandRefresh = Driver.Instance.FindElement(By.Id("7d7b23e0-7b19-4e61-a50b-44c3ac6a6d74-label"));
            Assert.That( commandNew.Text , Is.EqualTo( "جدید" ) );

        }

        internal static void ClickOnFormAccept( Form Form )
        {
            Driver.Instance.FindElement( By.Id( "990a3e70-73d5-4baa-b75f-7e6825acc4a8-label" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "FormLoadWhenClickOn Accept" );
        }

        internal static void VerifyKarkonanFormComplete( string FormTitle )
        {
            /*   IWebElement commandNew = Driver.Instance.WaitForLoadAnElementById("creation-commands-dropdown-label","CommandNew");
               IWebElement commandRefer = Driver.Instance.WaitForLoadAnElementById("3db38e7f-ffc2-4219-aaeb-995ca892c3a8-label","CommandRefer");
               IWebElement commandTag = Driver.Instance.WaitForLoadAnElementById("78354bec-04cd-4cc0-b535-a84c52390450-label","CommandTag");
               IWebElement commandRemoveFromWorkspace =Driver.Instance. WaitForLoadAnElementById("d600ff1f-86ee-4ada-b14a-ee86e8bfcfa8-label","commandRemoveFromWorkspace");
               IWebElement commandView = Driver.Instance.WaitForLoadAnElementById("cbcf8695-8302-40bf-95c5-c19eb4350db6-label","commandView");
               IWebElement commandEntityArchive = Driver.Instance.WaitForLoadAnElementById("2c990639-cbaa-4ec6-bb63-576e56941f0f-label","commandEntityArchive");
               IWebElement commandWorkTransactionCycle = Driver.Instance.WaitForLoadAnElementById("85b37846-1f3e-4cb7-ae98-00a21113366b-label","commandWorkTransactionCycle");
               IWebElement commandActions = Driver.Instance.WaitForLoadAnElementById("586fe5b6-a73e-4ef5-934d-c15b26b4d84b-label","commandActions");
               IWebElement commandCreateRelatedForm = Driver.Instance.WaitForLoadAnElementById("f709054b-5a52-443c-9f83-132c643f4a02-label","commandCreateRelatedForm");
               IWebElement commandWorkTransactionMoveToBeingProcessing = Driver.Instance.WaitForLoadAnElementById("328a80ac-fb90-46f9-ad97-7f6ef0e4a9e5-label","commandWorkTransactionMoveToBeingProcessing");
               IWebElement commandFurtherInformation = Driver.Instance.WaitForLoadAnElementById("1e3d2951-7cef-4385-b5a1-6c412a5a670c-label","commandFurtherInformation");
               IWebElement commandRefresh = Driver.Instance.WaitForLoadAnElementById("7d7b23e0-7b19-4e61-a50b-44c3ac6a6d74-label","commandRefresh");
               Assert.That( commandNew.Text , Is.EqualTo( "جدید" ) );
               Assert.That(commandRefer.Text , Is.EqualTo( "ارجاع"));
               Assert.That(commandTag.Text , Is.EqualTo( "برچسب"));
               Assert.That(commandRemoveFromWorkspace.Text , Is.EqualTo( "حذف از كارتابل"));
               Assert.That(commandView.Displayed , Is.EqualTo( true));
               Assert.That(commandEntityArchive.Text , Is.EqualTo( "بايگاني"));
               Assert.That(commandWorkTransactionCycle.Text , Is.EqualTo( "درختواره ارجاعات" ));
               Assert.That(commandActions.Text , Is.EqualTo( "اقدامات"));
               Assert.That(commandCreateRelatedForm.Text , Is.EqualTo( "ایجاد فرم مرتبط"));
               Assert.That(commandWorkTransactionMoveToBeingProcessing.Displayed , Is.EqualTo(true));
               Assert.That(commandFurtherInformation.Text , Is.EqualTo( "اطلاعات تکمیلی"));
               Assert.That(commandRefresh.Text , Is.EqualTo( "به روز رسانی"));*/
            string formName = "FormCompeleteCommand.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{formName}";
            IWebElement commands = Driver.Instance.WaitForLoadAnElementById("commands" , "Command Load");
            Bitmap screenshotimgFormCommand = Driver.Instance.TakeIWebElementScreenShot(commands);
            if( !File.Exists( filePath ) )
            {
                screenshotimgFormCommand.Save( filePath );
            }

            Bitmap bmpFormImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpFormImage, screenshotimgFormCommand);
            ErrorDetector.Detect();
            Assert.That( result , Is.True );
        }

        internal static void VerifyEntityInCartableListSelect( )
        {
            Driver.Instance.ImplicitWaitFor( "Selected Entity In Cartable" );
            IWebElement lstEntities = Driver.Instance.WaitForLoadAnElementById("WIL-list","List Of Entites");
            IWebElement selectedEntityInCartable = Driver.Instance.WaitForLoadAnElementByXPath("//tr[@aria-selected='true']" , "Entity In List");
            ErrorDetector.Detect();
            //string FormRow = chooseFormInList.FindElement(By.XPath("./..")).GetAttribute("aria-selected");
            Assert.That( lstEntities.Displayed , Is.EqualTo( true ) );
            Assert.That( selectedEntityInCartable.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnSearchText( )
        {
            Driver.Instance.FindElement( By.Name( "searchText" ) ).Click();
        }

        internal static void SendKeysSearchText( string FormTitle )
        {
            IWebElement txtSearch = Driver.Instance.FindElement(By.Name("searchText"));
            txtSearch.SendKeys( FormTitle );
            txtSearch.SendKeys( Keys.Enter );
            Driver.Instance.ImplicitWaitFor( " Result of Search List" );
        }

        internal static void VerifyWILListCommentForRejectedForm( Form Form )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime toDateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianToDateTime = Utility.ConvertDateToPersianDate(toDateTime);
            IWebElement rejectedComment = Driver.Instance.WaitForLoadAnElementByXPath($"//*[td [contains(.,'{Form.FormTitle}')] and td [contains(text() , '{persianFromDate}') or contains(text() , '{persianToDateTime}')] and td [.='‫عدم تاييد فرم']]","recive form");
            ErrorDetector.Detect();
            Assert.That( rejectedComment.Displayed , Is.EqualTo( true ) );
        }

        internal static void VerifyWillListCommentForConfirmedForm( Form Form )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime toDateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianToDateTime = Utility.ConvertDateToPersianDate(toDateTime);
            IWebElement rejectedComment = Driver.Instance.FindElement(By.XPath($"//*[td [contains(.,'{Form.FormTitle}')] and td [contains(text() , '{persianFromDate}') or contains(text() , '{persianToDateTime}')] and td [.='‫جهت اطلاع از تاييد فرم']]"));
            ErrorDetector.Detect();
            Assert.That( rejectedComment.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnFirstThreForms( Form Form )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime toDateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianToDateTime = Utility.ConvertDateToPersianDate(toDateTime);
            IWebElement recivedFormone = Driver.Instance.FindElement(By.XPath("//tr[2]//ins[@class='iCheck-helper']"));
            IWebElement recivedFormtwo = recivedFormone.FindElement (By.XPath ("//tr[3]//ins[@class='iCheck-helper']")); // find the next row
            IWebElement recivedFormthird = recivedFormone.FindElement (By.XPath ("//tr[4]//ins[@class='iCheck-helper']")); // find the next next row
            recivedFormone.Click();
            recivedFormtwo.Click();
            recivedFormthird.Click();
            Driver.Instance.ImplicitWaitFor( "select Form in Cartable" );
        }

        internal static void VerifyChosenFormsCommandsDisplayCorrectly( )
        {
            string formscommand = "mutipleselectedformscommand.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{formscommand}";

            IWebElement imgFormCommanssPreview = Driver.Instance.WaitForLoadAnElementById( "commands" , " multiple Forms command in cartable " );
            Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(imgFormCommanssPreview);

            if( !File.Exists( filePath ) )
            {
                bmpPageScreenshot.Save( filePath );
            }

            Bitmap bmpFormImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpFormImage, bmpPageScreenshot);
            ErrorDetector.Detect();
            Assert.That( result , Is.True );
        }

        internal static void ClickOnFormBatchAcceptCommand( )
        {
            Driver.Instance.WaitForLoadAnElementById( "38bb3f87-a870-45e7-8af7-08ab6ca90b62-label" , "Batch Accept Command In Cartable" ).Click();
            IWebElement btnStart = Driver.Instance.WaitForLoadAnElementById("start"," Start Button in Bath Accept Form");
            ErrorDetector.Detect();
            Assert.That( btnStart.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnUserProfile( )
        {
            IWebElement lnkUserProfile= Driver.Instance.WaitForClickOnElementByCssSelector(".user-active-position","User Profile Information");
            lnkUserProfile.Click();
            IWebElement btnSignOut = Driver.Instance.WaitForLoadAnElementByLinkText("خروج","Signout Button");
            ErrorDetector.Detect();
            Assert.That( btnSignOut.Displayed , Is.EqualTo( true ) );

        }

        internal static void ClickOnSignOutButton( )
        {
            Driver.Instance.WaitForLoadAnElementByLinkText( "خروج" , "Sign Out Button" ).Click();
            IWebElement txtUserName = Driver.Instance.WaitForLoadAnElementById("Username","UserName In Login Page");
            IWebElement txtPassword = Driver.Instance.WaitForLoadAnElementById("Password","Password In Login Page");
            IWebElement btnLogin = Driver.Instance.WaitForLoadAnElementById("login-button","login button");
            ErrorDetector.Detect();
            Assert.That( txtUserName.Displayed , Is.EqualTo( true ) );
            Assert.That( txtPassword.Displayed , Is.EqualTo( true ) );
            Assert.That( btnLogin.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnAdvancedSearch( )
        {
            Driver.Instance.FindElement(By.CssSelector(".advancedSearch")).Click();
            Driver.Instance.ImplicitWaitFor("Advance Search Page");
        }

        internal static void ClickOnNewOutgoingLetterCommand( )
        {
            Driver.Instance.FindElement(By.Id("2bc68c0a-45b6-445d-910f-0813389ba951-label")).Click();
            Driver.Instance.ImplicitWaitFor("Load Creation Outgoing Letter Page");
        }
    }
}


