using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
    public class LogoutSenario:TestBase
    {
        [Test]
        public void LogoutSucceed( )
        {
            LoginPage loginPage = new LoginPage( driver );
            loginPage.LoginSucceed( LoginData.userLoginAhmadi );
            LogoutPage logoutPage = new LogoutPage( driver );
            logoutPage.LogoutSucceed( );
        }
    }
}
