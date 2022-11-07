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
    public class ShellSenario : TestBase
    {


        [Test]
        public void OpenSucceedOfficeAutomation( )
        {
            LoginPage loginPage= new LoginPage(driver);
            loginPage.Login_Succeed( "administrator", "1" );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.OpenOfficeAutomation( );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            var logoElement = driver.FindElement(By.Id("logo-image"));
            var dataForValue = logoElement.GetAttribute("data-for");
            Assert.That( "cardtable",Is.EqualTo( dataForValue) );
        }
        [Test]
        public void LogOut( )
        {
        ShellPage shellPage = new ShellPage(driver);
            shellPage.LogOut( );
        }
    }
}
