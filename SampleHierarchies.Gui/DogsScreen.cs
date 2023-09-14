using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class DogsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    private SettingsService _settingsService;

    public override string ScreenDefinitionJson { get; set; } = "DogsScreen.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public DogsScreen(IDataService dataService, SettingsService settingsService)
    {
        _settingsService = settingsService;
        _dataService = dataService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetConsoleForegroundColor("DogsScreenFgColor");
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 0);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 1);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 2);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 3);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 4);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 5);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 6);
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 7);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                DogsScreenChoices choice = (DogsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case DogsScreenChoices.List:
                        ListDogs();
                        break;

                    case DogsScreenChoices.Create:
                        AddDog(); break;

                    case DogsScreenChoices.Delete: 
                        DeleteDog();
                        break;

                    case DogsScreenChoices.Modify:
                        EditDogMain();
                        break;

                    case DogsScreenChoices.Exit:
                        ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 8);
                        Thread.Sleep(800);
                        Console.Clear();
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 9);
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// List all dogs.
    /// </summary>
    private void ListDogs()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Dogs is not null &&
            _dataService.Animals.Mammals.Dogs.Count > 0)
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 10);
            int i = 1;
            foreach (Dog dog in _dataService.Animals.Mammals.Dogs)
            {
                Console.Write($"Dog number {i}, ");
                dog.Display();
                i++;
            }
        }
        else
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 11);
        }
    }

    /// <summary>
    /// Add a dog.
    /// </summary>
    private void AddDog()
    {
        try
        {
            Dog dog = AddEditDog();
            _dataService?.Animals?.Mammals?.Dogs?.Add(dog);
            Console.WriteLine("Dog with name: {0} has been added to a list of dogs", dog.Name);
        }
        catch
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 12);
        }
    }

    /// <summary>
    /// Deletes a dog.
    /// </summary>
    private void DeleteDog()
    {
        try
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 13);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                _dataService?.Animals?.Mammals?.Dogs?.Remove(dog);
                Console.WriteLine("Dog with name: {0} has been deleted from a list of dogs", dog.Name);
            }
            else
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 14);
            }
        }
        catch
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 15);
        }
    }

    /// <summary>
    /// Edits an existing dog after choice made.
    /// </summary>
    private void EditDogMain()
    {
        try
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 16);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                Dog dogEdited = AddEditDog();
                dog.Copy(dogEdited);
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 17);
                dog.Display();
            }
            else
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 18);
            }
        }
        catch
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 19);
        }
    }

    /// <summary>
    /// Adds/edit specific dog.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Dog AddEditDog()
    {
        ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 20);
        string? name = Console.ReadLine();
        ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 21);
        string? ageAsString = Console.ReadLine();
        ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 22);
        string? breed = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        int age = Int32.Parse(ageAsString);
        Dog dog = new Dog(name, age, breed);

        return dog;
    }

    #endregion // Private Methods
}
