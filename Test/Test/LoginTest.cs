using Test.Pages;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Tools.Senario;
using OpenQA.Selenium;

namespace Test.Senario
{
	[TestFixture]
	[Parallelizable(ParallelScope.All)]
    public class LoginTest : TestsBase
    {

        [Test]
        public  void LoadLoginPage( )
        {
			IWebDriver webDriver=GetAndLockDriver();
            LoginSenario.LoadLoginPage(webDriver);
			ReleaseServer(webDriver);
        }

        [Test, TestCaseSource( typeof( LoginData ) , nameof( LoginData.S_UserLoginData ) )]
        public void Login( UserLogin userLogin )
        {
            IWebDriver webDriver=GetAndLockDriver();
			LoginSenario.LoginSucceed(userLogin,webDriver);
			ReleaseServer(webDriver);
        }
    }
}
