using Newtonsoft.Json;
using SampleHierarchies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    public static class ScreenDefinitionService
    {
        public static ScreenDefinition Load(string jsonFileName)
        {
            if (File.Exists(jsonFileName))
            {
                string screenDefinitionAsString = File.ReadAllText(jsonFileName);
                ScreenDefinition? screenDefinition = JsonConvert.DeserializeObject<ScreenDefinition>(screenDefinitionAsString);
                if (screenDefinition != null)
                    return screenDefinition;
                else
                 return new ScreenDefinition();
            }
            else
            {
                throw new Exception($"File {jsonFileName} doesn't exist");
            }
        }

        public static void ShowLine(string jsonFileName, int lineNumber)
        {
            ScreenDefinition screenDefinition = Load(jsonFileName);
            if (screenDefinition.LineEntries != null)
            {
                Console.ForegroundColor = screenDefinition.LineEntries[lineNumber].ForegroundColor;
                Console.BackgroundColor = screenDefinition.LineEntries[lineNumber].BackgroundColor;
                Console.WriteLine(screenDefinition.LineEntries[lineNumber].Text);
                Console.ResetColor();
            }
            else
            {
                throw new Exception("Line entries is empty");
            }
        }
    }
}
