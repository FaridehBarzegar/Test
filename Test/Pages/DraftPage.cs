using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public static class DraftPage
    {
        internal static  void DraftPanelLoad( )
        {
            Driver.Instance.ImplicitWaitFor("Load Draft PAnel");
            IWebElement btnSettingButton      = Driver.Instance.FindElement( By.Id( "setting-button" ));
            IWebElement btnSignOutIcon        = Driver.Instance.FindElement( By.Id( "signout-icon" ));
            IWebElement btnMemorandomPanel    = Driver.Instance.FindElement( By.XPath("//dt[@data-cardtable-type='DraftMemorandum']"));
            IWebElement btnNewMemorandom      = Driver.Instance.FindElement( By.Id( "38153e8e-0e5e-4ad8-bc84-fa9e810023d2" ));
            IWebElement btnNewEform           = Driver.Instance.FindElement( By.Id( "43fa13dd-cb8f-4daf-be7a-c3712435c10b" ));
            IWebElement btnNewInternalLetter  = Driver.Instance.FindElement( By.Id( "e6b0b89c-f8b3-40ca-8c13-935a9032c662" ));
            IWebElement btnNewOutgoingLetter  = Driver.Instance.WaitForLoadAnElementById( "2bc68c0a-45b6-445d-910f-0813389ba951" ,"outgoingletter" );
            ErrorDetector.Detect();
            Assert.That( btnNewOutgoingLetter.Text , Is.EqualTo( "نامه صادره جدید" ));
            Assert.That( btnNewInternalLetter.Text , Is.EqualTo( "نامه داخلی جدید" ));
            Assert.That( btnNewMemorandom.Text , Is.EqualTo( "یادداشت اداری جدید" ));
            Assert.That( btnNewEform.Text , Is.EqualTo( "فرم جدید" ));
            Assert.That( btnSettingButton.Displayed , Is.EqualTo( true ));
            Assert.That( btnSignOutIcon.Displayed , Is.EqualTo( true ));
            Assert.That( btnMemorandomPanel.Displayed , Is.EqualTo( true ));
        }

        internal static void ClickOnMemorandomDraftPanel( )
        {
            IWebElement m_BtnMemorandomPanel= Driver.Instance.WaitForLoadAnElementByLinkText( "یادداشت اداری" ,"draftMemorandomPanel" );
            m_BtnMemorandomPanel.Click( );
        }

        internal static void ClickOnFormDraftPanel( )
        {
            IWebElement btnEFormPanel= Driver.Instance.WaitForLoadAnElementByLinkText( "فرم اداری" ,"draftEFormPanel" );
            btnEFormPanel.Click( );
        }
    }
}