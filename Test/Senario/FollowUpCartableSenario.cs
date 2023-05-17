using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
    public class FollowUpCartableSenario:AutomationSenarioBase
    {
        [Test]
        public void FollowUpCartableLoad( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenFollowUp( );
            FollowUpCartablePage followUpCartablePage = new FollowUpCartablePage(driver);
            followUpCartablePage.LoadFollowUpCartable( );
            cartablePage.CartableBackToShell( );
        }
    }
}
