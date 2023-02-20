using System;
using System.Diagnostics;
using System.ComponentModel;
using DetectLogicielMetier;

namespace TestDetectLogicielMetier
{
    public class Tests
    {
        
        [Test]
        public void TestProcessDetector()
        {
            DetectProcess detectProcess = new DetectProcess();

            detectProcess.ProcessDetector();


            Assert.That(detectProcess.Equals(true));
        }

        [Test]
        public void Test2()
        {


        }
    }
}