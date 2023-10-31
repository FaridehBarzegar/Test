using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public static class FormDraftPage
    {

        internal static void ClickOnFormViewCommand( Form form )
        {
            Driver.Instance.FindElement(By.XPath($"//tr[contains(.,'{form.FormTitle}')]")).Click();
            Driver.Instance.FindElement(By.Id("cbcf8695-8302-40bf-95c5-c19eb4350db6-label")).Click();
            Driver.Instance.ImplicitWaitFor("Show Form View ");
        }

        internal static void FormDraftPanelLoad( )
        {
            IWebElement FormPanel = Driver.Instance.FindElement(By.XPath("//dl[@class='arrows-left']/dt[3][@class='item empty selected']"));
            IWebElement form = Driver.Instance.WaitForLoadAnElementById( "1","form in List");
            ErrorDetector.Detect();
            Assert.That(FormPanel.Displayed , Is.EqualTo(true));
            Assert.That(form.Displayed , Is.EqualTo(true));
        }

        internal static void VerifyFormFieldsSave( Form Form )
        {
            IWebElement txtFullName= Driver.Instance.WaitForLoadAnElementByXPath($"//input[@value='{Form.FullName}']" , "fullName in draft Karkonan form");
            IWebElement txtPersonalCode= Driver.Instance.WaitForLoadAnElementByXPath($"//input[@value='{Form.PersonnelCode}']" ,"PersonalCode in Karkonan form draft " );
            ErrorDetector.Detect();
            Assert.That( txtFullName.Displayed , Is.EqualTo( true ) );
            Assert.That( txtPersonalCode.Displayed , Is.EqualTo( true ) );
        }

        internal static void VerifyFormSaveInDraft( string FormTitle )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime toDateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianToDateTime = Utility.ConvertDateToPersianDate(toDateTime);
            IWebElement title = Driver.Instance.FindElement( By.XPath( $"//tr[contains(.,'{FormTitle}')]" ) );
            var producedate = Driver.Instance.FindElement( By.XPath( $"//*[contains(text() ,'{persianFromDate}') or contains(text() , '{persianToDateTime}')]" ) );
            ErrorDetector.Detect();
            Assert.That( producedate.Displayed , Is.EqualTo( true ) );
            Assert.That( title.Displayed , Is.EqualTo( true ) );
        }
    }
}
