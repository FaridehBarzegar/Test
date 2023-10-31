using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;
using Test.Public;

namespace Test.Pages
{
    public  class MemorandomViewPage
    {
        /*
        private IWebDriver Driver.Instance;
       
        public MemorandomViewPage( IWebDriver driver )
        {
            Driver.Instance = driver;
        }

        public void EnsureMemorandomViewPageLoad( Memorandom memorandom )
        {
           IWebElement memorandomTitle       = Driver.Instance.FindElement(By.XPath($"//span[contains(@class,'title-text')]  [contains(text(),'{ memorandom.MemorandomTitle }')]"));
           IWebElement memmorandomReciver    = Driver.Instance.FindElement(By.XPath($"//span[contains(text(),'{memorandom.Reciver}')]"));
           IWebElement memorandomDiscreption = Driver.Instance.FindElement(By.XPath($"//span[contains(text(),'{memorandom.Description}')]"));
          
          // Assert.That( memorandomTitle.Displayed ,Is.EqualTo( true ));
          // Assert.That( memmorandomReciver.Displayed ,Is.EqualTo( true ));
           //Assert.That( memorandomDiscreption.Displayed ,Is.EqualTo( true ));
        }

        public void EnsureMemorandomViewPageLoadWithTranscriptReciver( string TranscriptReciver)
        {
            Driver.Instance.ImplicitWaitFor(PageEnums.memorandomView.ToString());
            IWebElement transcript = Driver.Instance.FindElement( By.XPath($"//span[contains(text(),'{TranscriptReciver}')]"));
            Assert.That( transcript.Displayed , Is.EqualTo( true ));
            //Assert.That(  memorandom.TranscriptOrder , Is.EqualTo(transcriptOrder.GetAttribute("value")));
        }*/
    }
}
