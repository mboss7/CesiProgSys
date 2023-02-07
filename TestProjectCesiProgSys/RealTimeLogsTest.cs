global using NUnit.Framework;


using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;

namespace EasySave.Tests
{
    [TestFixture]
    public class RealTimeLogsTest
    {
       // [Test]
        public async void RealTimeLogsTestFct()
        {
            // Arrange

            List<string> jsonInfo = new List<string>();
            jsonInfo.Add("Test");
            // Act
            RealTimeLogs.startThread();

            // Assert
            DirectoryInfo target = new DirectoryInfo("./LOGS/");
            
            Assert.That(target.Exists);
        }

    }
}
