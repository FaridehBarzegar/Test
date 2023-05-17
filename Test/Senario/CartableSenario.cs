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
        [Test]
        public void CartableLoad( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableBackToShell( );
        }
        [Test]
        public void CartableOpenFollowUp( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenFollowUp( );
            cartablePage.CartableBackToShell( );
        }
        [Test]
        public void CartableOpenCreateMemorandom( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenCreateMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.MemorandomCreateLoadPage( );
            cartablePage.CartableBackToShell( );
        }
        [Test]
        public void CartableOpenDraft( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenDraft( );
            DraftPage draftPage = new DraftPage(driver);
            draftPage.DraftPageLoad( );
            cartablePage.CartableBackToShell( );
        }
        [Test]
        public void CartableBackToShell( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableBackToShell( );
        
        }
    }
}
