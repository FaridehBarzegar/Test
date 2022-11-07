using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{

    public class CartablePage
    {
        public IWebDriver driver;
        public CartablePage( IWebDriver driver )
        {
            this.driver = driver;
        }

        public IWebElement ImgCartable => driver.FindElement(By.Id( "logo-image" ) );
        public IWebElement BtnNewMemorandom => driver.FindElement(By.Id( "38153e8e-0e5e-4ad8-bc84-fa9e810023d2" )                                                                                                                                                                                                   );
        //public IWebElement BtnNewMemorandom => driver.FindElement( By.XPath( "//*[@id='38153e8e-0e5e-4ad8-bc84-fa9e810023d2']/*[text()='یادداشت اداری جدید']" ) );
        //public IWebElement Btnlogin =>driver.FindElement(By.Id( "login-button" ) );

        public void Memorandom( )
        {
           
            BtnNewMemorandom.Click(  );
           
        }









































































































    }
}
