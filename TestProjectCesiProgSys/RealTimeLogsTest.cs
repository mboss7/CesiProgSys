global using NUnit.Framework;
using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization.Metadata;

namespace EasySave.Tests
{
    [TestFixture]
    public class RealTimeLogsTest
    {
        [Test]
        public async Task RealTimeLogsTestFct()
        {
            // Arrange

            List<string> jsonInfotest = new List<string>
            {
                JsonLog.stringToJson("Test")
            };



            // Act
            await RealTimeLogs.logInfo(jsonInfotest);
            
            // Assert
            DirectoryInfo target = new DirectoryInfo("./LOGS/");

            Assert.That(target.Exists);
        }

    }
}
