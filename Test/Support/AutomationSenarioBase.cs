using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Data;
using Test.Data.Objects;
using Test.Pages;

namespace Test.Support
{
    public class AutomationSenarioBase
    {
        public IWebDriver  driver;
        public ObjectPiker objectPiker = new ObjectPiker( );
        [SetUp]
        public void Setup( )
        {
            driver = new ChromeDriver( @"C:\Users\Administrator\source\repos\Test");
            driver.Manage( ).Window.Maximize( );
            driver.Navigate( ).GoToUrl( BaseCartableData.Url );
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginLoadPage( );
            objectPiker = ObjectPikerData.GetRandomRecivers( ).First( );
            UserLogin userLogin =LoginData.FindUserByUserName( objectPiker.userLogin);
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
