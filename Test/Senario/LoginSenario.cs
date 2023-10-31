using Test.Pages;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Tools.Senario;
using OpenQA.Selenium;

namespace Test.Senario
{
	[TestFixture]
    public class LoginSenario
    {

        public static void LoadLoginPage(IWebDriver webDriver )
        {
            LoginPage.LoadPage(webDriver);
        }

        public static void LoginSucceed( UserLogin userLogin , IWebDriver webDriver )
        {
            LoadLoginPage(webDriver);
            LoginPage.FillUserName( userLogin.UserName,webDriver );
            LoginPage.FillPassword( userLogin.Password,webDriver );
            LoginPage.ClickOnLogInButton( webDriver );
            ShellPage.VerifyShellPageLoad(webDriver);
        }
    }
}
