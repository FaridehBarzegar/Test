using OpenQA.Selenium;
using System.Drawing;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public static class FormPage
    {
        private static IWebElement m_btnInboxCartable =>
            Driver.Instance.FindElement( By.XPath( "//dt[@class='item empty  selected']//span[@class='title']" ) );
        private static IWebElement m_btnbeingProcessingCartable =>
            Driver.Instance.FindElement( By.PartialLinkText( "در دست اقدام" ) );
        private static IWebElement m_btnFollowUpCartable =>
            Driver.Instance.FindElement( By.XPath( "//a[@data-title='پیگیری ها']" ) );

        internal static void EnsureFormListIsLoaded( )
        {
            IWebElement tabHolder = Driver.Instance.FindElement( By.CssSelector(".tabholder"));
            string tabHolderStyle = tabHolder.GetAttribute( "style" );
            string style ="display: block; background-color: white; margin-right: -19px; margin-top: -3px; margin-bottom: 35px; border-style: none none solid; border-bottom-width: 1px; border-left-width: initial; border-right-width: initial; border-top-width: initial; border-color: rgb(233, 234, 238);";
            string FormTabColor = Driver.Instance.FindElement(By.Id("eformTab")).GetCssValue("color");
            IWebElement m_txtSearch = Driver.Instance.FindElement(By.Id("textSearchKey"));
            IWebElement formCategory = Driver.Instance.FindElement(By.CssSelector(".formCategory"));
            IWebElement m_lblForm = Driver.Instance.FindElement(By.LinkText( "اطلاعات پرسنل" ));
            ErrorDetector.Detect();
            Assert.That( tabHolder.Displayed , Is.EqualTo( true ) );
            Assert.That( tabHolderStyle , Is.EqualTo( style ) );
            Assert.That( "rgba(70, 23, 180, 1)" , Is.EqualTo( FormTabColor ) );
            Assert.That( m_txtSearch.Displayed , Is.EqualTo( true ) );
            Assert.That( formCategory.Displayed , Is.EqualTo( true ) );
            Assert.That( m_lblForm.Displayed , Is.EqualTo( true ) );
        }

        internal static void SetPersonnelInformationFormFields( Form form )
        {
            IWebElement txtFullName = Driver.Instance.WaitForLoadAnElementByXPath(" //div[@id='eFormTemplate']//div[2]/input[1] ","Fullname Field");
            IWebElement txtPersonelCode = Driver.Instance.WaitForLoadAnElementByXPath( "//div[@id='eFormTemplate']//div[4]/input[1]" ,"PersonnelCode");
            IWebElement chckDateOfBirth = Driver.Instance.FindElement(By.XPath ("//table[1]//div[@class='icheckbox_minimal-purple']" ));
            IWebElement txtDateOfBirth = Driver.Instance.WaitForLoadAnElementByXPath( "//table[1]//input[@class='hasDatepicker']" ,"Date Of Birth");
            IWebElement txtNationalCode = Driver.Instance.WaitForLoadAnElementByXPath( "//div[@id='eFormTemplate']//div[9]/input[1]" ,"National Code");
            IWebElement txtFathersName = Driver.Instance.WaitForLoadAnElementByXPath( "//div[@id='eFormTemplate']//div[11]/input[1]" ,"PersonnelCode");
            IWebElement chckJoinDate = Driver.Instance.WaitForLoadAnElementByXPath( "//table[2]//div[@class='icheckbox_minimal-purple']" ,"Join DateCheckBox");
            IWebElement txtJoinDate = Driver.Instance.WaitForLoadAnElementByXPath( "//table[2]//input[@class='hasDatepicker']" ,"Join DatePiker");
            //IWebElement optionGender = Driver.Instance.WaitForLoadAnElementByXPath( "//div[@id='eFormTemplate']//div[14]/select[1]" ,"Gender");
            txtFullName.SendKeys( form.FullName );
            txtPersonelCode.SendKeys( form.PersonnelCode );
            chckDateOfBirth.Click();
            txtDateOfBirth.SendKeys( form.DateOfBirth );
            txtNationalCode.SendKeys( form.NationalCode );
            txtFathersName.SendKeys( form.FathersName );
            chckJoinDate.Click();
            txtJoinDate.SendKeys( form.JoinDate );
          //  optionGender.Click();
            Driver.Instance.WaitForLoadAnElementByXPath($"//option[.='{form.Gender}']","Select Gender").Click();
        }

        internal static void ClickOnSaveButton( )
        {
            Driver.Instance.FindElement( By.Id( "d0e0364e-f5dc-42e3-adc8-182b29d98691-label" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "Save Karkonan Form" );
        }

        internal static void AcceptSaveAlert( )
        {
            Driver.Instance.FindElement( By.XPath( "//div[@id='dialogs']/div[2]//button[.='بلی']" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "AcceptSaveAlertForm" );
        }

        internal static void SetFormTitle( string FormTitle )
        {
            IWebElement txtFormTitle = Driver.Instance.FindElement( By.Id("eformNameSave"));
            txtFormTitle.Clear();
            txtFormTitle.SendKeys( FormTitle );
        }

        internal static void SetFormTitleInConfirmation( string FormTitle )
        {
            IWebElement txtFormTitle = Driver.Instance.FindElement( By.Id("eformName"));
            txtFormTitle.Clear();
            txtFormTitle.SendKeys( FormTitle );
        }

        internal static void AcceptSendAlert( )
        {
            IWebElement formAccept=Driver.Instance.WaitForLoadAnElementByXPath( "//div[@id='dialogs']/div[1]//button[.='بلی']" ,"accept form"); 
            formAccept.Click();
            Driver.Instance.WaitForLoadAnElementByCssSelector(".notify-elm","Notification Form Send");
            IWebElement  listEntityInCartable = Driver.Instance.WaitForLoadAnElementById( "WIL-list" ,"List Entities In Cartable" );
            ErrorDetector.Detect();
            Assert.That(listEntityInCartable.Displayed , Is.EqualTo(true));
        }
        internal static void AcceptConfirmationAlert( )
        {
            Driver.Instance.FindElement( By.XPath( "//body[@class='confirming']/div[4]//button[.='بلی']" ) ).Click();
            Driver.Instance.WaitForLoadAnElementByCssSelector(".notify-elm","Notification Form Send");
            IWebElement  listEntityInCartable = Driver.Instance.WaitForLoadAnElementById( "WIL-list" ,"List Entities In Cartable" );
            ErrorDetector.Detect();
            Assert.That(listEntityInCartable.Displayed , Is.EqualTo(true));
            //Driver.Instance.ImplicitWaitFor( "accept alert form confirmation" );
        }

        internal static void VerifyFormImageDisplay( )
        {
            string formName = "formInformationPersonnalCode.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{formName}";

            IWebElement imgFormPreview = Driver.Instance.WaitForLoadAnElementByXPath( "//div[@id='eFormTemplate']/div[contains(.,'نام و نام خانوادگي')]" , "FormTamplate" );
            Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(imgFormPreview);

            if( !File.Exists( filePath ) )
            {
                bmpPageScreenshot.Save( filePath );
            }

            Bitmap bmpFormImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpFormImage, bmpPageScreenshot);
            ErrorDetector.Detect();
            Assert.That( result , Is.True );
        }

        internal static void ClickOnConfirmCommand( )
        {
            Driver.Instance.FindElement( By.Id( "43a0d7a0-80e9-4cc5-b969-1fa408523451-label" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "Confirmation Form" );
        }

        internal static void VerifyFormFieldSave( Form Form )
        {
            IWebElement fullName= Driver.Instance.WaitForLoadAnElementByXPath($"//input[@value='{Form.FullName}']","fullNameField");
            IWebElement personalCode= Driver.Instance.WaitForLoadAnElementByXPath($"//input[@value='{Form.PersonnelCode}']","PersonalCodeField");
            ErrorDetector.Detect();
            Assert.That( fullName.Displayed , Is.EqualTo( true ) );
            Assert.That( personalCode.Displayed , Is.EqualTo( true ) );
        }

        internal static void ClickOnRejectButton( )
        {
            Driver.Instance.FindElement( By.Id( "ec3dcf96-7b33-439e-bc2f-d36edc30096d-label" ) ).Click();
            Driver.Instance.ImplicitWaitFor( "Reject Form" );
        }

        internal static void AcceptRejectionAlert( )
        {
            Driver.Instance.FindElement( By.Id( "textValue" ) ).SendKeys( "مورد تایید نمی‌باشد" );
            Driver.Instance.FindElement( By.XPath( "//body[1]/div[@class='ui-dialog ui-corner-all ui-widget ui-widget-content ui-front ui-dialog-buttons ui-draggable']//button[.='تایید']" ) ).Click();
            Driver.Instance.WaitForLoadAnElementByCssSelector(".notify-elm","Notification Form Send");
            Driver.Instance.ImplicitWaitFor("Load Cartable After Reject Form");
            IWebElement rowOfEntityInList = Driver.Instance.WaitForLoadAnElementByXPath("//tr[2]","entity in cartable list");
            ErrorDetector.Detect();
            Assert.That( rowOfEntityInList.Displayed , Is.EqualTo( true ) );
        }

        internal static void SetInvalidValueOfPersonnelInformationAgeField( )
        {
            IWebElement txtAge= Driver.Instance.FindElement(By.XPath("//div[@id='eFormTemplate']//div[6]/input[1]"));
            txtAge.SendKeys("45");
        }

        internal static void VerifyNotifyConditionAlert( )
        {
            IWebElement formAccept=Driver.Instance.WaitForLoadAnElementByXPath( "//div[@id='dialogs']/div[1]//button[.='بلی']" ,"accept form"); 
            formAccept.Click();
            IWebElement msgNotify = Driver.Instance.WaitForLoadAnElementByXPath("//p[text()='شرط انجام کار برقرار نمی باشد.']","Condition Notify");
            ErrorDetector.Detect();
            Assert.That(msgNotify.Displayed , Is.EqualTo(true));
        }
    }
}
