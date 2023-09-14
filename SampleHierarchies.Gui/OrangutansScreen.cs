using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public sealed class OrangutansScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        private SettingsService _settingsService;

        public override string ScreenDefinitionJson { get; set; } = "OrangutansScreen.json";

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public OrangutansScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.SetConsoleForegroundColor("OrangutansScreenFgColor");
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

                    OrangutansScreenChoices choice = (OrangutansScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case OrangutansScreenChoices.List:
                            ListOrangutans();
                            break;

                        case OrangutansScreenChoices.Create:
                            AddOrangutan();
                            break;

                        case OrangutansScreenChoices.Delete:
                            DeleteOrangutan();
                            break;

                        case OrangutansScreenChoices.Modify:
                            EditOrangutanMain();
                            break;

                        case OrangutansScreenChoices.Exit:
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
        /// List all orangutans.
        /// </summary>
        private void ListOrangutans()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Orangutans is not null &&
                _dataService.Animals.Mammals.Orangutans.Count > 0)
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 10);
                int i = 1;
                foreach (Orangutan orangutan in _dataService.Animals.Mammals.Orangutans)
                {
                    Console.Write($"Orangutan number {i}, ");
                    orangutan.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 11);
            }
        }

        /// <summary>
        /// Add an orangutan.
        /// </summary>
        private void AddOrangutan()
        {
            try
            {
                Orangutan orangutan = AddEditOrangutan();
                _dataService?.Animals?.Mammals?.Orangutans?.Add(orangutan);
                Console.WriteLine("Orangutan with name: {0} has been added to a list of orangutans", orangutan.Name);
            }
            catch
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 12);
            }
        }

        /// <summary>
        /// Deletes an orangutan.
        /// </summary>
        private void DeleteOrangutan()
        {
            try
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 13);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Orangutan? orangutan = (Orangutan?)(_dataService?.Animals?.Mammals?.Orangutans
                    ?.FirstOrDefault(o => o is not null && string.Equals(o.Name, name)));
                if (orangutan is not null)
                {
                    _dataService?.Animals?.Mammals?.Orangutans?.Remove(orangutan);
                    Console.WriteLine("Orangutan with name: {0} has been deleted from a list of orangutans", orangutan.Name);
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
        /// Edits an existing orangutan after choice made.
        /// </summary>
        private void EditOrangutanMain()
        {
            try
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 16);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Orangutan? orangutan = (Orangutan?)(_dataService?.Animals?.Mammals?.Orangutans
                    ?.FirstOrDefault(o => o is not null && string.Equals(o.Name, name)));
                if (orangutan is not null)
                {
                    Orangutan orangutanEdited = AddEditOrangutan();
                    orangutan.Copy(orangutanEdited);
                    ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 17);
                    orangutan.Display();
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
        /// Adds/edit specific orangutan.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Orangutan AddEditOrangutan()
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 20);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 21);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 22);
            string? intelligenceAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 23);
            string? climbingSpeedAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 24);
            string? diet = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 25);
            string? socialBehavior = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (intelligenceAsString is null)
            {
                throw new ArgumentNullException(nameof(intelligenceAsString));
            }
            if (climbingSpeedAsString is null)
            {
                throw new ArgumentNullException(nameof(climbingSpeedAsString));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            if (socialBehavior is null)
            {
                throw new ArgumentNullException(nameof(socialBehavior));
            }

            int age = Int32.Parse(ageAsString);
            int intelligence = Int32.Parse(intelligenceAsString);
            double climbingSpeed = Double.Parse(climbingSpeedAsString);

            Orangutan orangutan = new Orangutan(name, age, intelligence, climbingSpeed, diet, socialBehavior);

            return orangutan;
        }

        #endregion // Private Methods
    }
}
