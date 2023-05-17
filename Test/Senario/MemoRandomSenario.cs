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
    public class MemorandomSenario : AutomationSenarioBase
    {
        [Test]
        public void MemorandomCreateLoadPage( )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenCreateMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.MemorandomCreateLoadPage( );
            cartablePage.CartableBackToShell( );
        }

        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.ReadMemorandomFromExcell))]
        public void MemorandomSave(Memorandom memorandom)
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenCreateMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.MemorandomCreateLoadPage( );
            memorandomPage.MemorandomSave(  memorandom);
            cartablePage.CartableBackToShell( );

        }
        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.ReadMemorandomFromExcell))]
        public void MemorandomSend(Memorandom memorandom )
        {
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenCreateMemorandom( );
            MemorandomPage memorandomPage= new MemorandomPage(driver);
            memorandomPage.MemorandomCreateLoadPage( );
            memorandomPage.MemorandomSend(memorandom);
            cartablePage.CartableBackToShell( );
        }
        [Test,TestCaseSource(typeof(MemorandomData),nameof(MemorandomData.ReadMemorandomFromExcell))]
        public void MemorandomSaveAndSend(Memorandom memorandom )
        {
            CartablePage cartablePage= new CartablePage(driver);
            cartablePage.CartableLoaded( );
            cartablePage.CartableOpenCreateMemorandom( );
            MemorandomPage memorandomPage = new MemorandomPage(driver);
            memorandomPage.MemorandomCreateLoadPage( );
            memorandomPage.SaveAndSendNewMemorandom( memorandom);
            cartablePage.CartableBackToShell( );
        }
       
    }
}
