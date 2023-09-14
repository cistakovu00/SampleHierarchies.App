using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Animals main screen.
/// </summary>
public sealed class AnimalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private MammalsScreen _mammalsScreen;

    private SettingsService _settingsService;

    public override string ScreenDefinitionJson { get; set; } = "AnimalsScreen.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public AnimalsScreen(
        IDataService dataService,
        MammalsScreen mammalsScreen,
        SettingsService settingsService)
    {
        _dataService = dataService;
        _mammalsScreen = mammalsScreen;
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetConsoleForegroundColor("AnimalsScreenFgColor");
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 0);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 1);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 2);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 3);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 4);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 5);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 6);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case AnimalsScreenChoices.Mammals:
                        Console.Clear();
                        _mammalsScreen.Show();
                        break;

                    case AnimalsScreenChoices.Read:
                        Console.Clear();
                        ReadFromFile();
                        break;

                    case AnimalsScreenChoices.Save:
                        Console.Clear();
                        SaveToFile();
                        break;

                    case AnimalsScreenChoices.Exit:
                        ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 7);
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 8);
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Save to file.
    /// </summary>
    private void SaveToFile()
    {
        try
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 9);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            Console.WriteLine("Data saving to: '{0}' was successful.", fileName);
        }
        catch
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 10);
        }
    }

    /// <summary>
    /// Read data from file.
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 11);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            Console.WriteLine("Data reading from: '{0}' was successful.", fileName);
        }
        catch
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 12);
        }
    }

    #endregion // Private Methods
}
