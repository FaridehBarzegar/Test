using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
    public class LogoutSenario:TestBase
    {
        [Test]
        public void LogoutSucceed( )
        {
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout_Succeed( );
        }
    }
}
