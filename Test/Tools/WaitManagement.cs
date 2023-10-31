using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Test.Public
{
    public static class WaitManagement
    {
        public static void ImplicitWaitFor( this IWebDriver driver , string isFor )
        {
            try
            {
                driver.ImplicitDefaultWaitFor();

            }
            catch( Exception )
            {
                driver.ImplicitMaxWaitFor();
                Assert.Warn( $"{isFor} has been loaded late" );
            }
        }

        public static IWebElement WaitForLoadAnElementById( this IWebDriver drivwr , string id , string isFor )
        {
            try
            {
               return drivwr.DefaultWaitForLoadAnElementById( id );
            }
            catch( Exception )
            {
               IWebElement element = drivwr.MaxWaitForLoadAnElementById( id );
               Assert.Warn( $"{isFor} hae been loaded late" );
               return element;


            }
        }

        public static void WaitForPageLoad( this IWebDriver driver )
        {
            try
            {
                driver.DefaultWaitForPageLoad();
            }
            catch( Exception )
            {
                driver.MaxWaitForPageLoad();
                Assert.Warn("login page load late");
            }
        }

        public static IWebElement WaitForLoadAnElementByCssSelector( this IWebDriver driver , string cssSelector , string isFor )
        {
            try
            {
               return driver.DefaultWaitForLoadAnElementByCssSelector( cssSelector );
            }
            catch( Exception )
            {
               IWebElement element = driver.MaxWaitForLoadAnElementByCssSelector( cssSelector );
               Assert.Warn( $"{isFor} is Load Late" );
               return element;

            }
        }

        public static IWebElement WaitForLoadAnElementByXPath( this IWebDriver driver , string xPath , string isFor )
        {
            try
            {
              return  driver.DefaultWaitForLoadAnElementByXPath( xPath );
            }
            catch( Exception )
            {
               IWebElement element = driver.MaxWaitForLoadAnElementByXPath( xPath );
               Assert.Warn( $"{isFor} is Load Late " );
               return element;
            }
        }

        public static IWebElement WaitForLoadAnElementByLinkText( this IWebDriver driver , string linkText , string isFor )
        {
            try
            {
               return driver.DefaultWaitForLoadAnElementByLinkText( linkText );
            }
            catch( Exception )
            {
                IWebElement element = driver.MaxWaitForLoadAnElementByLinkText( linkText );
                Assert.Warn( $"{isFor} is load late" );
                return element;
            }
        }

        public static IWebElement WaitForClickOnElementById( this IWebDriver driver , string id , string isFor )
        {
            try
            {
               return driver.DefaultWaitForClickOnElementById( id );
            }
            catch( Exception )
            {
                IWebElement element = driver.MaxWaitForClickOnElementById( id );
                Assert.Warn( $"{isFor} is load late" );
                return element;
            }
        }

       
        public static IWebElement WaitForClickOnElementByCssSelector( this IWebDriver driver , string cssSelector , string isFor )
        {
            try
            {
               return driver.DefaultWaitForClickOnElementByCssSelector( cssSelector );
            }
            catch( Exception )
            {
                IWebElement element = driver.MaxWaitForClickOnElementByCssSelector( cssSelector );
                Assert.Warn( $"{isFor} is load late" );
                return element;
            }
        }

         public static IWebElement WaitForClickOnElementByXPath( this IWebDriver driver , string xpath , string isFor )
        {
            try
            {
               return driver.DefaultWaitForClickOnElementByXPath( xpath );
            }
            catch( Exception )
            {
                IWebElement element = driver.MaxWaitForClickOnElementByXPath( xpath );
                Assert.Warn( $"{isFor} is load late" );
                return element;
            }
        }

        public static void ImplicitDefaultWaitFor( this IWebDriver driver )
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault );
        }

        public static void ImplicitMaxWaitFor( this IWebDriver driver )
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut );
        }

        public static IWebElement DefaultWaitForLoadAnElementById( this IWebDriver driver , string id )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.Id( id ) ) );
        }

        public static IWebElement MaxWaitForLoadAnElementById( this IWebDriver driver , string id )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.Id( id ) ) );
        }

        public static void DefaultWaitForPageLoad( this IWebDriver driver )
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault );
        }

        public static void MaxWaitForPageLoad( this IWebDriver driver )
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut );
        }

        public static IWebElement DefaultWaitForLoadAnElementByLinkText( this IWebDriver driver , string linkText )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.LinkText( linkText ) ) );
        }

        public static IWebElement DefaultWaitForLoadAnElementByXPath( this IWebDriver driver , string xPath )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.XPath( xPath ) ) );
        }

        public static IWebElement DefaultWaitForLoadAnElementByCssSelector( this IWebDriver driver , string cssSelector )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.CssSelector( cssSelector ) ) );
        }

        public static IWebElement MaxWaitForLoadAnElementByLinkText( this IWebDriver driver , string linkText )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.LinkText( linkText ) ) );
        }

        public static IWebElement MaxWaitForLoadAnElementByXPath( this IWebDriver driver , string xPath )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.XPath( xPath ) ) );
        }

        public static IWebElement MaxWaitForLoadAnElementByCssSelector( this IWebDriver driver , string cssSelector )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut ) );
            return webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.CssSelector( cssSelector ) ) );
        }

         public static IWebElement DefaultWaitForClickOnElementByCssSelector( this IWebDriver driver , string cssSelector )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            return webDriverWait.Until( ExpectedConditions.ElementToBeClickable( By.CssSelector( cssSelector ) ) );
        }

         public static IWebElement MaxWaitForClickOnElementByCssSelector( this IWebDriver driver , string cssSelector )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut ) );
            return webDriverWait.Until( ExpectedConditions.ElementToBeClickable( By.CssSelector( cssSelector ) ) );
        }

         public static IWebElement DefaultWaitForClickOnElementByXPath( this IWebDriver driver , string xpath )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            return webDriverWait.Until( ExpectedConditions.ElementToBeClickable( By.XPath( xpath ) ) );
        }

         public static IWebElement MaxWaitForClickOnElementByXPath( this IWebDriver driver , string xpath )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut ) );
            return webDriverWait.Until( ExpectedConditions.ElementToBeClickable( By.CssSelector( xpath ) ) );
        }
         public static IWebElement DefaultWaitForClickOnElementById( this IWebDriver driver , string id )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            return webDriverWait.Until( ExpectedConditions.ElementToBeClickable( By.Id( id ) ) );
        }

         public static IWebElement MaxWaitForClickOnElementById( this IWebDriver driver , string id )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( driver , TimeSpan.FromSeconds( ConstItems.MaxWaitTimeOut ) );
            return webDriverWait.Until( ExpectedConditions.ElementToBeClickable( By.Id( id ) ) );
        }
    }
}
