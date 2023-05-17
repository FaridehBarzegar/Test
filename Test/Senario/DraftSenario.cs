using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
    public class DraftSenario:AutomationSenarioBase
    {
        [Test]
        public void DraftLoad( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            cartablePage.CartableBackToShell( );
        }
          [Test]
        public void DraftMemorandomOpenSucced( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.OpenSuccedMemorandomDraft( );
            cartablePage.CartableBackToShell( );
        }

     
    }
}
