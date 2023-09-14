using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public sealed class AfricanElephantsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        private SettingsService _settingsService;

        public override string ScreenDefinitionJson { get; set; } = "AfricanElephantsScreen.json";

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public AfricanElephantsScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.SetConsoleForegroundColor("AfricanElephantsScreenFgColor");
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

                    AfricanElephantsScreenChoices choice = (AfricanElephantsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AfricanElephantsScreenChoices.List:
                            ListAfricanElephants();
                            break;

                        case AfricanElephantsScreenChoices.Create:
                            AddAfricanElephant();
                            break;

                        case AfricanElephantsScreenChoices.Delete:
                            DeleteAfricanElephant();
                            break;

                        case AfricanElephantsScreenChoices.Modify:
                            EditAfricanElephantMain();
                            break;

                        case AfricanElephantsScreenChoices.Exit:
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
        /// List all African elephants.
        /// </summary>
        private void ListAfricanElephants()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.AfricanElephants is not null &&
                _dataService.Animals.Mammals.AfricanElephants.Count > 0)
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 10);
                int i = 1;
                foreach (AfricanElephant elephant in _dataService.Animals.Mammals.AfricanElephants)
                {
                    Console.Write($"African elephant number {i}, ");
                    elephant.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 11);
            }
        }

        /// <summary>
        /// Add an African elephant.
        /// </summary>
        private void AddAfricanElephant()
        {
            try
            {
                AfricanElephant elephant = AddEditAfricanElephant();
                _dataService?.Animals?.Mammals?.AfricanElephants?.Add(elephant);
                Console.WriteLine("African elephant with name: {0} has been added to the list of African elephants", elephant.Name);
            }
            catch
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 12);
            }
        }

        /// <summary>
        /// Deletes an African elephant.
        /// </summary>
        private void DeleteAfricanElephant()
        {
            try
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 13);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                AfricanElephant? elephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                    ?.FirstOrDefault(e => e is not null && string.Equals(e.Name, name)));
                if (elephant is not null)
                {
                    _dataService?.Animals?.Mammals?.AfricanElephants?.Remove(elephant);
                    Console.WriteLine("African elephant with name: {0} has been deleted from the list of African elephants", elephant.Name);
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
        /// Edits an existing African elephant after choice made.
        /// </summary>
        private void EditAfricanElephantMain()
        {
            try
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 16);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                AfricanElephant? elephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                    ?.FirstOrDefault(e => e is not null && string.Equals(e.Name, name)));
                if (elephant is not null)
                {
                    AfricanElephant elephantEdited = AddEditAfricanElephant();
                    elephant.Copy(elephantEdited);
                    ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 17);
                    elephant.Display();
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
        /// Adds/edits a specific African elephant.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private AfricanElephant AddEditAfricanElephant()
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 20);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 21);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 22);
            string? heightAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 23);
            string? weightAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 24);
            string? tuskLengthAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 25);
            string? longLifeSpanAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 26);
            string? socialBehavior = Console.ReadLine();

            if (name is null || ageAsString is null || heightAsString is null || weightAsString is null ||
                tuskLengthAsString is null || longLifeSpanAsString is null || socialBehavior is null)
            {
                throw new ArgumentNullException("One or more fields are empty.");
            }

            int age = Int32.Parse(ageAsString);
            float height = float.Parse(heightAsString, CultureInfo.InvariantCulture);
            float weight = float.Parse(weightAsString, CultureInfo.InvariantCulture);
            float tuskLength = float.Parse(tuskLengthAsString, CultureInfo.InvariantCulture);
            int longLifeSpan = Int32.Parse(longLifeSpanAsString);
            AfricanElephant elephant = new AfricanElephant(name, age, height, weight, tuskLength, longLifeSpan, socialBehavior);

            return elephant;
        }

        #endregion // Private Methods
    }

}
