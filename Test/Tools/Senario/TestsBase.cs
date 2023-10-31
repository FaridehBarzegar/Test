using OpenQA.Selenium;
using System.Collections.Concurrent;
using Test.Pages;
using Test.Public;
using Test.Tools;

namespace Test.Tools.Senario
{

	public class TestsBase
	{
		private static ConcurrentQueue<IWebDriver> s_drivers = new System.Collections.Concurrent.ConcurrentQueue<IWebDriver>( );

		private string m_currentServerUrl;

		static TestsBase( )
		{
		}

		[OneTimeSetUp]
		public static void BaseSetup( )
		{
			var webDriver = Driver.ChromeInstance( );
			webDriver.Manage( ).Window.Maximize( );
			webDriver.Navigate( ).GoToUrl( "http://localhost:8084/" );
			webDriver.WaitForPageLoad( );
			s_drivers.Enqueue( webDriver );

			var webDriver2 = Driver.ChromeInstance( );
			webDriver2.Manage( ).Window.Maximize( );
			webDriver2.Navigate( ).GoToUrl( "http://localhost:8085/" );
			webDriver2.WaitForPageLoad( );
			s_drivers.Enqueue( webDriver2 );

			var webDriver3 = Driver.ChromeInstance( );
			webDriver3.Manage( ).Window.Maximize( );
			webDriver3.Navigate( ).GoToUrl( "http://localhost:8086/" );
			webDriver3.WaitForPageLoad( );
			s_drivers.Enqueue( webDriver3 );
		}

		[OneTimeTearDown]
		public static void CloseDriver( )
		{
			//try
			//{
			//	LogoutPage.LogoutSucceed( );
			//}
			//finally
			//{
			//	Driver.DisposeInstance( );
			//}
		}

		protected static IWebDriver GetAndLockDriver( )
		{
			IWebDriver result;
			if( !s_drivers.TryDequeue( out result ))
				throw new InvalidOperationException( "No release driver found" );

			return result;
		}
		protected static void ReleaseServer( IWebDriver driver )
		{
			s_drivers.Enqueue( driver );
		}

	}
}
