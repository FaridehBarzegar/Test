using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;

namespace Test.Support
{
    public class TestBase
    {
        public IWebDriver  driver;

        [SetUp]
        public void Setup( )
        {
            driver = new ChromeDriver( );
            driver.Manage( ).Window.Maximize( );
            driver.Navigate( ).GoToUrl( "http://localhost:8084/" );
        }
        [TearDown]
        public void CloseDriver( )
        {
            try
            {
                LogoutPage logoutPage = new LogoutPage( driver );
                logoutPage.LogoutSucceed( );
                
            }
            catch(Exception exp){
                throw exp;
                }
            finally
            {
                driver.Close( );
                driver.Quit( );
                driver.Dispose( );
            }
        }
    }
}
