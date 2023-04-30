using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;

namespace Test.Senario
{
    public class MemoRandomSenario : AutomationSenarioBase
    {
        [Test]
        public void NewMemorandomLoaded( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.NewMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.NewMemorandomLoaded( );
            cartablePage.BackToShell( );
        }

        [Test]
        public void SaveNewMemorandom( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.NewMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.NewMemorandomLoaded( );
            memorandomPage.SaveNewMemorandom( );
            cartablePage.BackToShell( );

        }
        [Test]
        public void SendMemorandom( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.NewMemorandom( );
            MemorandomPage memorandomPage= new MemorandomPage(driver);
            memorandomPage.NewMemorandomLoaded( );
            memorandomPage.SendNewMemorandom( );
            cartablePage.BackToShell( );
        }
        [Test]
        public void MemorandomSaveAndSend( )
        {
            CartablePage cartablePage= new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.NewMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.NewMemorandomLoaded( );
            memorandomPage.SaveAndSendNewMemorandom( );
            cartablePage.BackToShell( );
        }
    }
}
