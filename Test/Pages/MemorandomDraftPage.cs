using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Test.Public;

namespace Test.Pages
{
    public class MemorandomDraftPage
    {
     /*   private  IWebDriver Driver.Instance;
        private  WebDriverWait webDriverWait;
        private  IWebElement m_btnNewMemorandom                            => Driver.Instance.FindElement( By.Id( "38153e8e-0e5e-4ad8-bc84-fa9e810023d2" ));
        private  IWebElement m_btnNewOutgoingLetter                        => Driver.Instance.FindElement( By.Id( "2bc68c0a-45b6-445d-910f-0813389ba951" ));
        private  IWebElement m_btnNewInternalLetter                        => Driver.Instance.FindElement( By.Id( "e6b0b89c-f8b3-40ca-8c13-935a9032c662" ));
        private  IWebElement m_btnNewForm                                 => Driver.Instance.FindElement( By.Id( "43fa13dd-cb8f-4daf-be7a-c3712435c10b" ));
        private  IWebElement m_btnView                                    => Driver.Instance.FindElement( By.Id( "6b343511-b47a-4469-9a4c-778c91d7a5b0-label" ) );
        private  IWebElement m_btnEdit                                    => Driver.Instance.FindElement( By.Id( "a47c6a87-7acc-4188-ad43-85aec131fdb3-label" ) );
        private  IWebElement m_btnDelete                                    => Driver.Instance.FindElement( By.Id( "b1d2bf73-f21e-418d-8be0-b8039bb391ec-label" ) );

        public MemorandomDraftPage( IWebDriver driver )
        {
            Driver.Instance = driver;
        }
         public  void EnsureMemorandomDraftPageReady( )
        {
            IWebElement m_btnNewOutgoingLetter =Driver.Instance.WaitForLoadAnElementById( "2bc68c0a-45b6-445d-910f-0813389ba951" , "newOutgoigLetter" );
            IWebElement m_btnNewInternalLetter = Driver.Instance.WaitForLoadAnElementById(  "e6b0b89c-f8b3-40ca-8c13-935a9032c662" ,"newInternalLetter" );
            IWebElement m_btnNewMemorandom = Driver.Instance.WaitForLoadAnElementById(  "38153e8e-0e5e-4ad8-bc84-fa9e810023d2" ,"newMemorandom" );
            IWebElement m_btnNewForm = Driver.Instance.WaitForLoadAnElementById(  "43fa13dd-cb8f-4daf-be7a-c3712435c10b" ,"newForm" );
            Assert.That( m_btnNewOutgoingLetter.Text ,Is.EqualTo( "نامه صادره جدید" ));
            Assert.That( m_btnNewInternalLetter.Text , Is.EqualTo( "نامه داخلی جدید" ));
            Assert.That( m_btnNewMemorandom.Text , Is.EqualTo( "یادداشت اداری جدید" ));
            Assert.That( m_btnNewForm.Text  , Is.EqualTo( "فرم جدید" ));
            IWebElement m_btnMemorandomPanel=  Driver.Instance.WaitForLoadAnElementByLinkText( "یادداشت اداری" ,"memorandomPanel");
            Assert.That(  m_btnMemorandomPanel.Displayed , Is.EqualTo( true ));
        }

         public void EnsureMemorandomISSave( string memorandomTitle )
        {
            DateTime fromDateTime = DateTime.Now;
            string persianFromDate = Utility.ConvertDateToPersianDate( fromDateTime );
            IWebElement title = Driver.Instance.FindElement( By.XPath( $"//tr[contains(.,'{memorandomTitle}')]" ) );
            var producedate = Driver.Instance.FindElement( By.XPath( $"//*[contains(text() ,'{persianFromDate}')]" ) );
            Assert.That( producedate.Displayed , Is.EqualTo( true ) );
            Assert.That( title.Displayed , Is.EqualTo( true ) );
        }

        public void ClickMemorandomInList( )
        {
            Driver.Instance.FindElement( By.Id( "1" )).Click( );
            IWebElement m_btnView = Driver.Instance.WaitForLoadAnElementById( "6b343511-b47a-4469-9a4c-778c91d7a5b0-label" , "viewCommand" );
            Assert.That( m_btnView.Displayed , Is.EqualTo( true));
            Assert.That( m_btnEdit.Displayed , Is.EqualTo( true));
            Assert.That( m_btnDelete.Displayed , Is.EqualTo( true));

        }

        public MemorandomViewPage ClickOnViewCommand( )
        {
            m_btnView.Click( );
            Driver.Instance.ImplicitWaitFor(PageEnums.memorandomView.ToString());
            return new MemorandomViewPage( Driver.Instance );

        }

       
        // public  void SendMemorandomInDraft( )
        //{
        //   Driver.Instance.FindElement( By.Id( "7f4bc636-4abb-41f1-82f9-d0ed7c036819" )).Click();
        //   Driver.Instance.ImplicitWaitFor( 5 );
        //   Driver.Instance.FindElement(By.Id("1")).Click();
        //   Driver.Instance.ImplicitWaitFor( 5 );
           
        //}*/
    }
}
