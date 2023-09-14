using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;

    private SettingsService _settingsService;

    public override string ScreenDefinitionJson { get; set; } = "MainScreen.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        SettingsService settingsService)
    {
        _dataService = dataService;
        _animalsScreen = animalsScreen;
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetConsoleForegroundColor("MainScreenFgColor");
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 0);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 1);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 2);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 3);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 4);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 5);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        Console.Clear();
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        break;

                    case MainScreenChoices.Exit:
                        ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 6);
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 7);
            }
        }
    }

    #endregion // Public Methods
}