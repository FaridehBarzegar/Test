using OpenQA.Selenium;
using System;
using System.Drawing;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public static class FollowUpCartablePage
    {
        private static IWebElement m_BtnFollowUpCartable => Driver.Instance.FindElement( By.XPath( "//dt[@class='item empty selected']//span[text()='پیگیری ها']" ) );
        private static IWebElement m_Btnexpandservices => Driver.Instance.FindElement( By.Id( "expand-services" ) );
        private static IWebElement m_BtnBackToShell => Driver.Instance.FindElement( By.CssSelector( "[alt='ليست برنامه‌ها']" ) );

        internal static void VerifyFollowUpCartablePageIsLoadedCorrectly( )
        {

            Driver.Instance.ImplicitWaitFor("Load FollowUP Cartable") ;
            IWebElement commands             = Driver.Instance.FindElement(By.Id("commands"));
            IWebElement listEntityInCartable = Driver.Instance.FindElement(By.Id("WIL-list" ));
            IWebElement btnNewCommand        = Driver.Instance.FindElement(By.Id( "c3314d78-55b6-4711-a004-c463581072e1-label" ));
            IWebElement btnNewOutgoingLetter1= Driver.Instance.FindElement(By.Id( "2bc68c0a-45b6-445d-910f-0813389ba951-label" ));
            IWebElement btnNewInternalLetter = Driver.Instance.FindElement(By.Id( "e6b0b89c-f8b3-40ca-8c13-935a9032c662-label" ));
            IWebElement btnNewMemorandom     = Driver.Instance.FindElement(By.Id( "38153e8e-0e5e-4ad8-bc84-fa9e810023d2-label"));
            IWebElement btnNewForm          = Driver.Instance.FindElement(By.Id( "43fa13dd-cb8f-4daf-be7a-c3712435c10b-label" ));
            IWebElement btnRefresh           = Driver.Instance.FindElement(By.Id( "7d7b23e0-7b19-4e61-a50b-44c3ac6a6d74-label" ));
            ErrorDetector.Detect();
            Assert.That( listEntityInCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( m_BtnBackToShell.Displayed , Is.EqualTo( true ) );
            Assert.That( m_Btnexpandservices.Displayed , Is.EqualTo( true ) );
            Assert.That( m_BtnFollowUpCartable.Displayed , Is.EqualTo( true ) );
            Assert.That( commands.Displayed , Is.EqualTo( true ) );
            Assert.That( btnNewCommand.Displayed , Is.EqualTo( true ) );
            Assert.That( btnNewOutgoingLetter1.Displayed , Is.EqualTo( true) );
            Assert.That( btnNewInternalLetter.Displayed , Is.EqualTo( true) );
            Assert.That( btnNewMemorandom.Displayed , Is.EqualTo( true) );
            Assert.That( btnNewForm.Displayed , Is.EqualTo( true ) );
            Assert.That( btnRefresh.Displayed , Is.EqualTo(true) );
        }

        internal static void EnsureMemorandomISSend( Memorandom memorandom )
        {
            DateTime fromDateTime = DateTime.Now;
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            IWebElement title = Driver.Instance.FindElement( By.XPath( $"//tr[contains(.,'{memorandom.MemorandomTitle}')]" ) );
            IWebElement produceDate = Driver.Instance.FindElement( By.XPath( $"//*[contains(text() , '{persianFromDate}')]" ) );
            ErrorDetector.Detect();
            Assert.That( produceDate.Displayed , Is.EqualTo( true ) );
            Assert.That( title.Displayed , Is.EqualTo( true ) );
        }

        internal static void VerifyFormIsSendCorrectly( string FormTitle )
        {
            DateTime fromDateTime = DateTime.Now;
            DateTime dateTime = fromDateTime.Subtract(TimeSpan.FromMinutes( 1 ));
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            string persianDateTime = Utility.ConvertDateToPersianDate(dateTime);
            IWebElement title = Driver.Instance.WaitForLoadAnElementByXPath( $"//tr[contains(.,'{FormTitle}')]" ,"Form Title");
            var producedate = Driver.Instance.WaitForLoadAnElementByXPath(  $"//*[contains(text() ,'{persianFromDate}') or contains(text() , '{persianDateTime}')]" ,"Form Recive" );
            ErrorDetector.Detect();
            Assert.That( producedate.Displayed , Is.EqualTo( true ) );
            Assert.That( title.Displayed , Is.EqualTo( true ) );
        }
    }
}
