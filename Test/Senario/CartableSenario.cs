using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
    public class CartableSenario: AutomationSenarioBase
    {
        [Test,Order(1)]
        public void CartableLoad( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.BackToShell( );
        }
        [Test]
        public void CartableFollowupLoaded( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.LoadFollowupCartable( );
            cartablePage.BackToShell( );
        }
        [Test,Order((2))]
        public void NewMemoRandom( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.NewMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.NewMemorandomLoaded( );
            cartablePage.BackToShell( );
        }
        [Test,Order(3)]
        public void OpenDraft( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.OpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            cartablePage.BackToShell( );
        }
        [Test,Order(4)]
        public void BackToShell( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.BackToShell( );
        
        }
    }
}
