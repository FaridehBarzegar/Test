using OpenQA.Selenium;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Pages;
using Test.Tools.Senario;

namespace Test.Senario
{
	[TestFixture]
	public class LogoutSenario : TestsBase
	{
		public static void LogoutUser( UserLogin userLogin,IWebDriver webDriver )
		{

			LoginSenario.LoginSucceed( userLogin,webDriver );
			// CartableSenario.BackToShell();
			LogoutPage.LogoutSucceed( webDriver);
			LoginPage.LoadPage(webDriver );
		}

		public static void QuickSignOut( UserLogin userLogin,IWebDriver webDriver )
		{
			LoginSenario.LoginSucceed( userLogin,webDriver );
			ShellSenario.CartableLoad( );
			CartablePage.ClickOnUserProfile( );
			CartablePage.ClickOnSignOutButton( );
			LoginPage.LoadPage( webDriver );
		}
	}
}
