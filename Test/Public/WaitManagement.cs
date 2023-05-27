using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Public
{
    public static class WaitManagement
    {
        public static void ImplicitWaitFor(this IWebDriver driver, int  timeOut )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( timeOut );
        }

            public static void WaitForPageLoad(this IWebDriver driver, int  timeOut )
        {
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( timeOut );
        }
        
        public static IWebElement WaitForLoadAnElementById(this IWebDriver driver, int  timeOut,string id  )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( timeOut ));
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.Id( id ))); 
            
        }

         public static IWebElement WaitForLoadAnElementByLinkText(this IWebDriver driver, int  timeOut,string linkText  )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( timeOut ));
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.LinkText( linkText ))); 
            
        }

         public static IWebElement WaitForLoadAnElementByXPath(this IWebDriver driver, int  timeOut,string xPath  )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( timeOut ));
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.XPath( xPath ))); 
            
        }
    }
}
