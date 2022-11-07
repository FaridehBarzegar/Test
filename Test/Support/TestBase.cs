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
            driver.Navigate( ).GoToUrl( "https://192.168.12.145" );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );

        }
        [TearDown]
        public void CloseDriver( )
        {
            driver.Close();
            driver.Quit( );
            driver.Dispose( );
            
        }
    }
}
