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
            cartablePage.CardtableLoaded( );
            cartablePage.OpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            cartablePage.BackToShell( );
        }

        [Test]
        public void MemorandomDraftLoad( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.OpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.MemorandomDraftLoad( );
            cartablePage.BackToShell( );
        }
    }
}
