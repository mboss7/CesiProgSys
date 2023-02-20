using CesiProgSys.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcp_Ssl;

namespace TestProjectCesiProgSys
{

    [TestFixture]
    internal class TestViewModelWpf
    {
        [Test]
       public void ViewModelTcpSSL_Run()
        {
            //arrange 
            ViewModelWpf ViewModelTest = new ViewModelWpf();

            //act


            ViewModelTest.ViewModelWpf_RunSslSrv();


            //assert

            Assert.That(TcpServer.isRunning, Is.EqualTo(true));


            // clean 
                        
        }


    }
}
