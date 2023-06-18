using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
       
    public class MemorandomDraftSenario:AutomationSenarioBase
    {   

        [Test]
        public void MemorandomDraftLoad( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.OpenSuccedMemorandomDraft();
            MemorandomDraftPage memorandomDraftPage = new MemorandomDraftPage(driver);
            memorandomDraftPage.DraftMemorandomLoaded();
            cartablePage.CartableBackToShell( );
        }
        [Test]
        public void MemorandomDraftEditPageLoad( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            draftPage.OpenSuccedMemorandomDraft( );
            MemorandomDraftPage memorandomDraftPage = new MemorandomDraftPage(driver);
            memorandomDraftPage.DraftMemorandomLoaded();
            memorandomDraftPage.DraftMemorandomEditPageLoad( );
            cartablePage.CartableBackToShell( );
        }
         [Test]
        public void SendMemorandomInDraft( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
             draftPage.OpenSuccedMemorandomDraft( );
            MemorandomDraftPage memorandomDraftPage = new MemorandomDraftPage(driver);
            memorandomDraftPage.DraftMemorandomLoaded();
            memorandomDraftPage.DraftMemorandomEditPageLoad( );
            memorandomDraftPage.SendMemorandomInDraft( );
            cartablePage.CartableBackToShell( );
        }
    }
}
