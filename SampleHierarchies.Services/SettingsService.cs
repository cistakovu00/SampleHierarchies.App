using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region 

    /// <inheritdoc/>
    public ISettings? Read(string jsonPath)
    {
        ISettings? result = null;

        return result;
    }

    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {
        
    }

    public void SetConsoleForegroundColor(string screenName)
    {
        try
        {
            // Чтение JSON из файла
            string json = File.ReadAllText("settings.json");
            Settings? colorSettings = JsonConvert.DeserializeObject<Settings>(json);

            if (colorSettings != null)
            {
                if (colorSettings.MainScreenFgColor != null && colorSettings.AnimalsScreenFgColor != null && colorSettings.MammalsScreenFgColor != null && colorSettings.BearsScreenFgColor != null && colorSettings.DogsScreenFgColor != null && colorSettings.OrangutansScreenFgColor != null && colorSettings.AfricanElephantsScreenFgColor != null)
                {
                    string fgColor;
                    switch (screenName)
                    {
                        case "MainScreenFgColor":
                            fgColor = colorSettings.MainScreenFgColor;
                            break;
                        case "AnimalsScreenFgColor":
                            fgColor = colorSettings.AnimalsScreenFgColor;
                            break;
                        case "MammalsScreenFgColor":
                            fgColor = colorSettings.MammalsScreenFgColor;
                            break;
                        case "DogsScreenFgColor":
                            fgColor = colorSettings.DogsScreenFgColor;
                            break;
                        case "BearsScreenFgColor":
                            fgColor = colorSettings.BearsScreenFgColor;
                            break;
                        case "OrangutansScreenFgColor":
                            fgColor = colorSettings.OrangutansScreenFgColor;
                            break;
                        case "AfricanElephantsScreenFgColor":
                            fgColor = colorSettings.AfricanElephantsScreenFgColor;
                            break;
                        default:
                            fgColor = "White"; 
                            break;
                    }

                    if (Enum.TryParse(fgColor, out ConsoleColor consoleColor))
                    {
                        Console.ForegroundColor = consoleColor;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White; 
                    }
                }
            }
            else
            {
                throw new Exception("Error");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    #endregion 
}