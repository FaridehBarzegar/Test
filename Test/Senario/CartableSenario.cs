using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
    public class CartableSenario:TestBase
    {
        
         
        [Test]
        public void NewMemoRandom( )
        {
            LoginPage loginPage= new LoginPage(driver);
            loginPage.Login_Succeed( "administrator", "1" );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.OpenOfficeAutomation( );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.Memorandom( );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );

        }
    }
}
