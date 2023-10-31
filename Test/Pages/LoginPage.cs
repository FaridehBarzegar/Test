using OpenQA.Selenium;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public class LoginPage
	{
		public string Username
		{
			get; set;
		}
		public string Password
		{
			get; set;
		}


		private static IWebElement m_btnLogIn => Driver.Instance.FindElement( By.Id( "login-button" ) );
		private static IWebElement m_linkForgotPassword => Driver.Instance.FindElement( By.Id( "ForgetPasword_link" ) );
		private static IWebElement m_labelVersionNumber => Driver.Instance.FindElement( By.LinkText( "1.000.00 : ویرایش" ) );
		private static IWebElement m_labelEnglishLanguage => Driver.Instance.FindElement( By.LinkText( "English" ) );
		private static IWebElement m_labelPersianLanguage => Driver.Instance.FindElement( By.LinkText( "فارسی" ) );

		internal static void LoadPage( IWebDriver driver )
		{
			IWebElement txtUserName = driver.FindElement( By.Id( "Username" ) );
			IWebElement txtPassword = driver.FindElement( By.Id( "Password" ) );
			driver.ImplicitWaitFor( "Login Page" );
			ErrorDetector.Detect( );
			Assert.That( txtUserName.Displayed, Is.EqualTo( true ) );
			Assert.That( txtPassword.Displayed, Is.EqualTo( true ) );
			Assert.That( m_btnLogIn.Displayed, Is.EqualTo( true ) );
			Assert.That( m_linkForgotPassword.Text, Is.EqualTo( "رمز عبور را فراموش کرده ام" ) );
			Assert.That( m_labelVersionNumber.Text, Is.EqualTo( "1.000.00 : ویرایش" ) );
			Assert.That( m_labelPersianLanguage.Text, Is.EqualTo( "فارسی" ) );
			Assert.That( m_labelEnglishLanguage.Text, Is.EqualTo( "English" ) );
		}

		internal static void FillUserName( string userName,IWebDriver driver )
		{
			IWebElement txtUserName = driver.FindElement( By.Id( "Username" ) );
			IWebElement txtPassword = driver.FindElement( By.Id( "Password" ) );
			txtUserName.Click( );
			txtUserName.SendKeys( userName );
		}

		internal static void FillPassword( string userpassword,IWebDriver driver )
		{
			IWebElement txtUserName = driver.FindElement( By.Id( "Username" ) );
			IWebElement txtPassword = driver.FindElement( By.Id( "Password" ) );
			txtPassword.Click( );
			txtPassword.SendKeys( userpassword );
		}

		internal static void ClickOnLogInButton( IWebDriver driver )
		{
			m_btnLogIn.Click( );
			driver.ImplicitWaitFor( PageEnums.ShellPage.ToString( ) );

			try
			{
				driver.SwitchTo( ).Alert( ).Accept( );
			}
			catch { }
		}
		//public void CheckUserIsLogin( )
		//{
		//    try
		//    {
		//        Driver.Instance.SwitchTo().Alert().Accept();
		//    }
		//    catch( NoAlertPresentException ex )
		//    {
		//        string m_txtShellHeader = Driver.Instance.FindElement(By.ClassName("top-Payvast-Title")).Text;
		//        StringAssert.AreEqualIgnoringCase( "سازمان الکترونیک پیوست" , m_txtShellHeader );
		//    }
		//}
	}
}
