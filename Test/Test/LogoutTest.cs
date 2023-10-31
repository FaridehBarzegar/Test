using OpenQA.Selenium;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Pages;
using Test.Tools.Senario;

namespace Test.Senario
{
	[TestFixture]
	public class LogoutTest : TestsBase
	{
		[Test, TestCaseSource( typeof( LoginData ), nameof( LoginData.S_UserLoginData ) )]
		public void LogoutUser( UserLogin userLogin )
		{
			IWebDriver webDriver = GetAndLockDriver();
			// CartableSenario.BackToShell();
			LogoutSenario.LogoutUser( userLogin, webDriver );
			ReleaseServer(webDriver);
		}

		[Test, TestCaseSource( typeof( LoginData ), nameof( LoginData.S_UserLoginData ) )]
		public static void QuickSignOut( UserLogin userLogin )
		{
			IWebDriver webDriver = GetAndLockDriver();
			LogoutSenario.QuickSignOut(userLogin,webDriver);
			ReleaseServer(webDriver);
		}
	}
}
