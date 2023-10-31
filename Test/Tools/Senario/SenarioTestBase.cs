using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Pages;
using Test.Senario;
using Test.Tools;

namespace Test.Tools.Senario
{
	public class SenarioTestBase : TestsBase
	{
		/*

		[SetUp]
		public void Setup( )
		{
			try
			{
				Login( );

			}
			catch
			{
				LogoutUser( );
				Login( );
			}
		}

		private static void Login( )
		{
			WebDriver.Navigate( ).Refresh( );
			BaseObject baseObject = ( BaseObject ) TestContext.CurrentContext.Test.Arguments[ 0 ];
			UserLogin userLogin = LoginData.FindUserByUserName( baseObject.UserLogin );
			LoginTest.LoginSucceed( userLogin );
		}

		public void TakeScreenshotDefaultImagFormat( )
		{

			if( TestContext.CurrentContext.Result.Outcome.Status == ResultState.Error.Status )
			{
				var screenshot = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
				var screenshotDirectoryPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots\\");
				if( !Directory.Exists( screenshotDirectoryPath ) )
					Directory.CreateDirectory( screenshotDirectoryPath );
				var currentDate = DateTime.Now;
				var filePath = $"{screenshotDirectoryPath}{TestContext.CurrentContext.Test.Name}_{currentDate.ToString("yyyy.MM.dd-HH.mm.ss")}.png";
				screenshot.SaveAsFile( filePath );
				TestContext.AddTestAttachment( filePath );
			}
		}
		[TearDown]
		public void LogoutUser( )
		{

			try
			{
				TakeScreenshotDefaultImagFormat( );
			//	LogoutPage.LogoutSucceed( );

			}
			catch( Exception ex )
			{
				CartablePage.BackToShell( );
				ShellPage.VerifyShellPageLoad( );
				//LogoutPage.LogoutSucceed( );
			}
		}*/
	}
}
