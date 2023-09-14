using SampleHierarchies.Data;
using SampleHierarchies.Services;
using System;

namespace SampleHierarchies.ServicesTests
{
    [TestClass]
    public class ScreenDefinitionServiceTests
    {
        private string jsonFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "existing.json");

        [TestMethod]
        public void Load_ExistingJsonFile_ReturnsScreenDefinition()
        {
            // Arrange
            if (!File.Exists(jsonFileName))
            {
                File.WriteAllText(jsonFileName, "{\"LineEntries\": []}");
            }

            ScreenDefinition screenDefinition = ScreenDefinitionService.Load(jsonFileName);
            Assert.IsNotNull(screenDefinition);
      
            File.Delete(jsonFileName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Load_NonExistingJsonFile_ThrowsException()
        {
            string jsonFileName = "nonexisting.json";
            ScreenDefinition screenDefinition = ScreenDefinitionService.Load(jsonFileName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShowLine_InvalidLineNumber_ThrowsException()
        {
            string jsonFileName = "existing.json"; 
            int lineNumber = -1;
            ScreenDefinitionService.ShowLine(jsonFileName, lineNumber);
        }
    }
}
