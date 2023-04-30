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
            driver.Close( );
            driver.Quit( );
            driver.Dispose( );
        }
    }
}
