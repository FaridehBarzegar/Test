using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Data.Object;
using Test.Pages;

namespace Test.Support
{
    public class AutomationSenarioBase
    {
        public IWebDriver  driver;

        [SetUp]
        public void Setup( )
        {
            driver = new ChromeDriver( );
            driver.Manage( ).Window.Maximize( );
            driver.Navigate( ).GoToUrl( BaseCartableData.Url );
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginLoadPage( );
            UserLogin userLogin = LoginData.GetRandomUsers().First();
            loginPage.LoginSucceed( userLogin );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellLoadPage( );
            shellPage.OpenOfficeAutomation( );
        }

        [TearDown]
        public void CloseDriver( )
        {
            try
            {
                LogoutPage logoutPage = new LogoutPage( driver );
                logoutPage.LogoutSucceed( );

            }
            catch( Exception ex )
            {
                throw ex;
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
