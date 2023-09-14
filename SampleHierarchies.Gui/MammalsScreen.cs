using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;

    private SettingsService _settingsService;

    /// <summary>
    /// African elephants screen.
    /// </summary>
    private AfricanElephantsScreen _aficanElephantsScreen;

    /// <summary>
    /// Bears screen.
    /// </summary>
    private BearsScreen _bearsScreen;

    /// <summary>
    /// Orangutans screen.
    /// </summary>
    private OrangutansScreen _orangutansScreen;

    public override string ScreenDefinitionJson { get; set; } = "MammalsScreen.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, AfricanElephantsScreen africanElephantsScreen, BearsScreen bearsScreen, OrangutansScreen orangutansScreen, SettingsService settingsService)
    {
        _settingsService = settingsService;
        _dogsScreen = dogsScreen;
        _aficanElephantsScreen = africanElephantsScreen;
        _bearsScreen = bearsScreen;
        _orangutansScreen = orangutansScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetConsoleForegroundColor("MammalsScreenFgColor");
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

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        Console.Clear();
                        _dogsScreen.Show();
                        break;

                    case MammalsScreenChoices.Africanelephants:
                        Console.Clear();
                        _aficanElephantsScreen.Show();
                        break;

                    case MammalsScreenChoices.Bears:
                        Console.Clear();
                        _bearsScreen.Show();
                        break;

                    case MammalsScreenChoices.Orangutans:
                         Console.Clear();
                        _orangutansScreen.Show();
                        break;

                    case MammalsScreenChoices.Exit:
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
}
