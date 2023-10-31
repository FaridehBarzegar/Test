using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Test.Data.Objects;
using Test.Public;

namespace Test.Pages
{
    public class MemorandomActionsPage
    {
       /* private  IWebDriver Driver.Instance;
        private  IWebElement m_Txtmemorandumtitle =>  Driver.Instance.FindElement( By.Id( "memorandum-title" ) );

        
        public  void MemorandomViewPageLoadAttachment( Memorandom memorandom , ObjectPiker objectPiker )
        {
           //MemorandomViewPageLoad( memorandom , objectPiker );
         //  IWebElement memorandomAttahment= Driver.Instance.WaitForLoadAnElementByXPath( $"//a[contains(text(),'{memorandom.FileAttachmentName}')]");
           //IWebElement memorandomAttahment = driver.FindElement(By.XPath($"//a[contains(text(),'{memorandom.fileAttachmentName}')]"));
           //Assert.That( memorandomAttahment.Displayed ,Is.EqualTo( true ));
        }

        public  void DraftMemorandomViewPageLoadTranscriptReferral( Memorandom memorandom , ObjectPiker objectPiker , string transcriptOrder )
        {
           //MemorandomViewPageLoad( memorandom , objectPiker );
          // Driver.Instance.ImplicitWaitFor();
           IWebElement memorandomtranscriptOrderReferral = Driver.Instance.FindElement(By.XPath($"//span[contains(text(),'{transcriptOrder}')]"));
           Assert.That( memorandomtranscriptOrderReferral.Displayed ,Is.EqualTo( true ));
        }

         public  void MemorandomDeleteInDraft(  bool delete )
        {
           IWebElement firstMemorandomElement= Driver.Instance.FindElement( By.XPath( "//tr[@id='1']" )).FindElement( By.XPath("//td[@aria-describedby='WIL-list_entityId']"));
           string firstMemorandomId = firstMemorandomElement.GetAttribute("title");
           Driver.Instance.FindElement(By.Id("1")).Click();
          // Driver.Instance.WaitForLoadAnElementById("b1d2bf73-f21e-418d-8be0-b8039bb391ec-label").Click( );
           IWebElement showAlertDelete = Driver.Instance.FindElement( By.XPath("//div[@id='dialogConfirmationText'] [text()='آيا از حذف مورد/موارد انتخاب شده مطمئن هستید؟']"));
           Assert.That( showAlertDelete.Displayed ,Is.EqualTo( true ));
           if( delete )
            {
                Driver.Instance.FindElement( By.XPath("//button[@id='button1']")).FindElement(By.XPath("//span[text()='بلی']")).Click( );
              //  Driver.Instance.ImplicitWaitFor(  );
                Driver.Instance.FindElement( By.XPath("//tr[@id='1']")).FindElement( By.XPath("//td[@aria-describedby='WIL-list_cb']")).Click( );
                //MemorandomDraftPage.LoadMemorandomDraftList( );
                IWebElement memorandomElement= Driver.Instance.FindElement( By.XPath( "//tr[@id='1']" )).FindElement( By.XPath("//td[@aria-describedby='WIL-list_entityId']"));
                string memorandomId = memorandomElement.GetAttribute("title");
                Assert.That( firstMemorandomId , Is.Not.EqualTo( memorandomId ));

            }
           else
                Driver.Instance.FindElement( By.XPath("//button[@id='button1']")).FindElement(By.XPath("//span[text()='خیر']")).Click( );
           }

         public  void MemorandomEditPageLoad( )
         {
            IWebElement firstRow =  Driver.Instance.WaitForLoadAnElementById( "1" ,"firstRowOfCartable" );
            firstRow.Click();
           // Driver.Instance.WaitForLoadAnElementById(  "a47c6a87-7acc-4188-ad43-85aec131fdb3" );
            IWebElement m_ObjTo=Driver.Instance.WaitForLoadAnElementById( "To_text" ,"reciver");
            IWebElement m_CkEditor = Driver.Instance.WaitForLoadAnElementById( "cke_1_top" ,"ck_editor" );
            Assert.That(m_ObjTo.Displayed , Is.EqualTo( true ));
            Assert.That(m_Txtmemorandumtitle.Displayed , Is.EqualTo( true ));
            Assert.That(m_CkEditor.Displayed , Is.EqualTo( true ));
            
         }

       */
    }
}
