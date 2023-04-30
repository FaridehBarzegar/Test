using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Test.Pages
{
    public class DraftPage
    {
        private IWebDriver driver;
        private  WebDriverWait webDriverWait;
        public DraftPage( IWebDriver driver )
        {
            this.driver = driver;
        }
        private IWebElement m_BtnNewMemorandom => driver.FindElement( By.Id( "38153e8e-0e5e-4ad8-bc84-fa9e810023d2" ));
        private IWebElement m_BtnNewOutgoingLetter => driver.FindElement( By.Id( "2bc68c0a-45b6-445d-910f-0813389ba951" ));
        private IWebElement m_BtnNewInternalLetter => driver.FindElement( By.Id( "e6b0b89c-f8b3-40ca-8c13-935a9032c662" ));
        private IWebElement m_BtnNewEform => driver.FindElement( By.Id( "43fa13dd-cb8f-4daf-be7a-c3712435c10b" ) );
        private IWebElement m_BtnSettingButton => driver.FindElement( By.Id( "setting-button" ));
        private IWebElement m_BtnSignOutIcon => driver.FindElement( By.Id( "signout-icon" ));
        private IWebElement m_BtnMemorandomPanel => driver.FindElement( By.LinkText( "یادداشت اداری" ));


        public void DraftPageLoad( )
        {
            CartablePage cartablePage = new CartablePage( driver );
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 7 ));
            IWebElement m_BtnNewOutgoingLetter1= webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.Id( "2bc68c0a-45b6-445d-910f-0813389ba951" )));
            Assert.AreEqual( "نامه صادره جدید", m_BtnNewOutgoingLetter1.Text );
            Assert.AreEqual( "نامه داخلی جدید", m_BtnNewInternalLetter.Text );
            Assert.AreEqual( "یادداشت اداری جدید", m_BtnNewMemorandom.Text );
            Assert.AreEqual( "فرم جدید", m_BtnNewEform.Text );
            Assert.AreEqual( true, m_BtnSettingButton.Displayed);
            Assert.AreEqual( true, m_BtnSignOutIcon.Displayed);
            Assert.AreEqual( true, m_BtnMemorandomPanel.Displayed);

        }

        public void MemorandomDraftLoad( )
        {
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 8 ) );
            IWebElement m_BtnMemorandomPanel= webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.LinkText( "یادداشت اداری" )));
            m_BtnMemorandomPanel.Click( );
            Assert.AreEqual( "یادداشت اداری", m_BtnMemorandomPanel.Text);
        }
    }
}