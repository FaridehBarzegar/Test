using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Public;

namespace Test.Pages
{
    public class MemorandomDraftPage
    {
        private IWebDriver driver;
        private WebDriverWait webDriverWait;
        private IWebElement m_BtnNewMemorandom                            => driver.FindElement( By.Id( "38153e8e-0e5e-4ad8-bc84-fa9e810023d2" ));
        private IWebElement m_BtnNewOutgoingLetter                        => driver.FindElement( By.Id( "2bc68c0a-45b6-445d-910f-0813389ba951" ));
        private IWebElement m_BtnNewInternalLetter                        => driver.FindElement( By.Id( "e6b0b89c-f8b3-40ca-8c13-935a9032c662" ));
        private IWebElement m_BtnNewEform                                 => driver.FindElement( By.Id( "43fa13dd-cb8f-4daf-be7a-c3712435c10b" ) );
        private IWebElement m_BtnMemorandomEdit                           => driver.FindElement( By.Id( "a47c6a87-7acc-4188-ad43-85aec131fdb3" ) );
         private IWebElement m_ObjTo                                      => driver.FindElement( By.Id( "To_text" ) );
        private IWebElement m_ObjTranscriptItems0TranscriptToAsPosition   => driver.FindElement( By.Id( "TranscriptItems_0_TranscriptToAsPosition_text" ) );
        private IWebElement m_TxtTranscriptItems0TranscriptReason         => driver.FindElement( By.Id( "TranscriptItems_0__TranscriptReason" ) );
        private IWebElement m_BtnAdd                                      => driver.FindElement( By.Id( "add" ) );
        private IWebElement m_ChckCopyMemorandom                          => driver.FindElement( By.XPath( "//div[@id='memorandum-button-wrapper']/div[1]/div[@class='table-cell']" ) );
        // private IWebElement m_ChckAdditionalData_HasTranscriptFollowUp => driver.FindElement( By.XPath( "//div[@class='icheckbox_minimal-purple checked']/ins[@class='iCheck-helper']" ));
        private IWebElement m_Txtmemorandumtitle                          => driver.FindElement( By.Id( "memorandum-title" ) );
        private IWebElement m_Btnimportanceflag                           => driver.FindElement( By.ClassName( "importance-flag" ) );
        private IWebElement m_CkEditor                                    => driver.FindElement( By.Id( "cke_1_top" ) );
        private IWebElement m_ContentMemorandom                           => driver.FindElement( By.CssSelector( "#cke_1_contents > iframe" ) );

        public MemorandomDraftPage(IWebDriver driver )
        {
            this.driver = driver;

        }
         public void DraftMemorandomLoaded( )
        {
            driver.ImplicitWaitFor( 7 );
            CartablePage cartablePage = new CartablePage( driver );
            IWebElement m_BtnNewOutgoingLetter = WaitManagement.WaitForLoadAnElementById( driver , 7,"2bc68c0a-45b6-445d-910f-0813389ba951" );
            Assert.AreEqual( "نامه صادره جدید", m_BtnNewOutgoingLetter.Text );
            Assert.AreEqual( "نامه داخلی جدید", m_BtnNewInternalLetter.Text );
            Assert.AreEqual( "یادداشت اداری جدید", m_BtnNewMemorandom.Text );
            Assert.AreEqual( "فرم جدید", m_BtnNewEform.Text );
            IWebElement m_BtnMemorandomPanel=  WaitManagement.WaitForLoadAnElementByLinkText( driver , 7, "یادداشت اداری" );
            Assert.AreEqual( true, m_BtnMemorandomPanel.Displayed);
            
        }
        public void DraftMemorandomEditPageLoad( )
        {
            driver.FindElement(By.Id("1")).Click();
            driver.ImplicitWaitFor( 5 );
            m_BtnMemorandomEdit.Click();
            IWebElement m_ObjTo=WaitManagement.WaitForLoadAnElementById( driver, 7 ,"To_text" );
            Assert.AreEqual(true,m_ObjTo.Displayed);
            Assert.AreEqual(true,m_Txtmemorandumtitle.Displayed);
            Assert.AreEqual(true,m_CkEditor.Displayed);
            
        }
         public void MemorandomDraftSend( )
        {
            driver.FindElement( By.Id( "7f4bc636-4abb-41f1-82f9-d0ed7c036819" )).Click();
            driver.ImplicitWaitFor( 5 );
            driver.FindElement(By.Id("1")).Click();
           driver.ImplicitWaitFor( 5 );
           
        }
    }
}
