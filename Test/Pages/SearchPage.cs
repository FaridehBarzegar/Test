using OpenQA.Selenium;
using System.Drawing;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public static class SearchPage
    {
        internal static void ClickOnFormAccept( Form Form )
        {
            Driver.Instance.FindElement( By.Id( "990a3e70-73d5-4baa-b75f-7e6825acc4a8-label" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "Load Form in Search Result When click on Accept Command" );
        }

        internal static void ClickOnFormInSearchResult( IWebElement efoemRecived )
        {
            efoemRecived.Click();
            Driver.Instance.ImplicitWaitFor( "FormCommand in Search Result" );
        }

        internal static void VerifyResultOfSearchPageIsLoadedCorrectly( )
        {
            Driver.Instance.ImplicitWaitFor( " Result Of Search entitesList" );
            IWebElement txtSearch = Driver.Instance.FindElement(By.CssSelector(".search.selected"));
            IWebElement entitiesInCartable = Driver.Instance.WaitForLoadAnElementById("WIL-list","List Entity In Cartable");
            IWebElement btnInboxCartable = Driver.Instance.FindElement(By.XPath("//dt[@data-cardtable-type='Inbox']"));
            IWebElement btnFollowUpCartable = Driver.Instance.FindElement(By.XPath("//dt[@data-cardtable-type='FollowUp']"));
            IWebElement btnBeingProcessingCartable = Driver.Instance.FindElement(By.XPath("//dt[@data-cardtable-type='BeingProcessing']"));
            IWebElement commands = Driver.Instance.WaitForLoadAnElementById("commands" , "Coammands In Search");
            ErrorDetector.Detect();
            Assert.That( txtSearch.Displayed , Is.EqualTo( true ) );
            Assert.That( entitiesInCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( btnInboxCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( btnFollowUpCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( btnBeingProcessingCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( commands.Displayed , Is.EqualTo( true ) );
        }

        internal static void VerifyFormCammandsLoadInSearchResult( )
        {
            IWebElement Commands = Driver.Instance.WaitForLoadAnElementById("commands","Form Commands in Search Result ");
            IWebElement btnNewCommand = Driver.Instance.WaitForLoadAnElementById("creation-commands-dropdown-label","New Command in Form selected in Search result");
            IWebElement btnReferCommand = Driver.Instance.WaitForLoadAnElementById("3db38e7f-ffc2-4219-aaeb-995ca892c3a8-label","Refer Command in Form selected in Search result");
            IWebElement btnFormAcceptCommand = Driver.Instance.WaitForLoadAnElementById("990a3e70-73d5-4baa-b75f-7e6825acc4a8-label","FormAccept Command in Form selected in Search result");
            IWebElement btnFormbatchacceptCommand = Driver.Instance.WaitForLoadAnElementById("38bb3f87-a870-45e7-8af7-08ab6ca90b62-label","Formbatchaccept Command in Form selected in Search result");
            IWebElement btnArchiveCommand = Driver.Instance.WaitForLoadAnElementById("2c990639-cbaa-4ec6-bb63-576e56941f0f-label","Archive Command in Form selected in Search result");
            IWebElement btnWorkTransactionCycleCommand = Driver.Instance.WaitForLoadAnElementById("85b37846-1f3e-4cb7-ae98-00a21113366b-label","WorkTransactionCycle Command in Form selected in Search result");
            IWebElement btnActionsCommand = Driver.Instance.WaitForLoadAnElementById("586fe5b6-a73e-4ef5-934d-c15b26b4d84b-label","ActionsCommand Command in Form selected in Search result");
            IWebElement btnWorkTransactionMoveToBeingProcessingCommand = Driver.Instance.WaitForLoadAnElementById("328a80ac-fb90-46f9-ad97-7f6ef0e4a9e5-label","Command in Form selected in Search result");
            IWebElement btnCompleteinfoCommand = Driver.Instance.WaitForLoadAnElementById("1e3d2951-7cef-4385-b5a1-6c412a5a670c-label","WorkTransactionMoveToBeingProcessing Command in Form selected in Search result");
            IWebElement btnCancelCommand = Driver.Instance.WaitForLoadAnElementById("ca00c6da-21dd-44aa-b87c-223a2c1be490-label"," Cancel Command in Form selected in Search result");
            ErrorDetector.Detect();
            Assert.That( Commands.Displayed , Is.EqualTo( true ) );
            Assert.That( btnNewCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnReferCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnFormAcceptCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnFormbatchacceptCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnArchiveCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnWorkTransactionCycleCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnActionsCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnWorkTransactionMoveToBeingProcessingCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnCompleteinfoCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnCancelCommand.Displayed , Is.EqualTo( true ) );
        }

        internal static IWebElement VerifyFormIsFindInSearchResult( string FormTitle )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime toDateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianToDateTime = Utility.ConvertDateToPersianDate( toDateTime );
            IWebElement recivedForm =
            Driver.Instance.WaitForLoadAnElementByXPath($"//*[td [contains(.,'{FormTitle}')] and td [contains(text() , '{persianFromDate}') or contains(text() , '{persianToDateTime}')] ]","recive form" );
            ErrorDetector.Detect();
            // Assert.That( recivedFormTitle.Displayed , Is.EqualTo( true ) );
            Assert.That( recivedForm.Displayed , Is.EqualTo( true ) );
            return recivedForm;
        }

        internal static IWebElement VerifyFormIsFindInAdvancedSearchResult( string FormTitle )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime toDateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianToDateTime = Utility.ConvertDateToPersianDate(toDateTime);
            IWebElement btnLastWILPage = Driver.Instance.WaitForLoadAnElementById("last_WIL-pager","Button Of Last Page");
            btnLastWILPage.Click();
            Driver.Instance.ImplicitWaitFor( "Result Of end Page of Search" );
            IWebElement recivedForm =
            Driver.Instance.WaitForLoadAnElementByXPath($"//*[td [contains(.,'{FormTitle}')] and td [contains(text() , '{persianFromDate}') or contains(text() , '{persianToDateTime}')] ]","recive form" );
            ErrorDetector.Detect();
            // Assert.That( recivedFormTitle.Displayed , Is.EqualTo( true ) );
            Assert.That( recivedForm.Displayed , Is.EqualTo( true ) );
            return recivedForm;
        }


        internal static void VerifyLoadAdvancedSearchPage( )
        {
            string advancedSearchPageimg = "advanceSearchPage.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{advancedSearchPageimg}";

            IWebElement advancedSearchPageimage = Driver.Instance.WaitForLoadAnElementByCssSelector( ".advanced-search" , "advanced search page" );
            Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(advancedSearchPageimage);

            if( !File.Exists( filePath ) )
            {
                bmpPageScreenshot.Save( filePath );
            }

            Bitmap bmpAdvancedSearchImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpAdvancedSearchImage, bmpPageScreenshot);
            ErrorDetector.Detect();
            Assert.That( result , Is.True );
        }

        internal static void ClickOnFormOptions( )
        {
            Driver.Instance.FindElement( By.CssSelector( "[tabindex='1']" ) ).Click();
            Driver.Instance.FindElement( By.XPath( "//a[.='فرم']" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "Advanced Form Page" );
        }

        internal static void VerifyLoadFormAdvancedPage( )
        {
            string FormAdvancedSearchPageimg = "FormadvanceSearchPage.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{FormAdvancedSearchPageimg}";

            IWebElement FormAdvancedSearchPageimage = Driver.Instance.WaitForLoadAnElementByCssSelector( ".advanced-search" , "advanced search page" );
            Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(FormAdvancedSearchPageimage);

            if( !File.Exists( filePath ) )
            {
                bmpPageScreenshot.Save( filePath );
            }

            Bitmap bmpFormAdvancedSearchImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpFormAdvancedSearchImage, bmpPageScreenshot);
            ErrorDetector.Detect();
            Assert.That( result , Is.True );
        }
        /// <summary>
        /// 
        /// </summary>
        internal static void FillSearchText( )
        {
            Driver.Instance.FindElement( By.Id( "SearchCriteriaStructuredFormTemplate_old_text" ) ).SendKeys( "اطلاعات پرسنل" );
            Driver.Instance.WaitForLoadAnElementByXPath( "//ul[.='اطلاعات پرسنل']" , "KarkonanForm in result of search" ).Click();
            Driver.Instance.ImplicitWaitFor( "Result Of Form Advanced Search" );
        }

        internal static void ClickOnSearchCommand( )
        {
            Driver.Instance.FindElement( By.Id( "d8ede877-4d7b-4150-8d46-a00a269b0ffd-label" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "Result Of Form Advanced Search " );
        }

        internal static void SetFormAttributes( Form Form )
        {
            Driver.Instance.FindElement( By.Id( "AttributeValues_11_" ) ).SendKeys( Form.FullName );
        }

        internal static void ClickOnFormBatchAcceptCommand( Form Form )
        {
            Driver.Instance.FindElement( By.Id( "38bb3f87-a870-45e7-8af7-08ab6ca90b62-label" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "Batch Accept Form Load" );
        }
    }
}
