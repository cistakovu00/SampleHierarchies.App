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
    public sealed class BearsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        private SettingsService _settingsService;

        public override string ScreenDefinitionJson { get; set; } = "BearsScreen.json";

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public BearsScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.SetConsoleForegroundColor("BearsScreenFgColor");
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

                    BearsScreenChoices choice = (BearsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case BearsScreenChoices.List:
                            ListBears();
                            break;

                        case BearsScreenChoices.Create:
                            AddBear();
                            break;

                        case BearsScreenChoices.Delete:
                            DeleteBear();
                            break;

                        case BearsScreenChoices.Modify:
                            EditBearMain();
                            break;

                        case BearsScreenChoices.Exit:
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
        /// List all bears.
        /// </summary>
        private void ListBears()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Bears is not null &&
                _dataService.Animals.Mammals.Bears.Count > 0)
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 10);
                int i = 1;
                foreach (Bear bear in _dataService.Animals.Mammals.Bears)
                {
                    Console.Write($"Bear number {i}, ");
                    bear.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 11);
            }
        }

        /// <summary>
        /// Add a bear.
        /// </summary>
        private void AddBear()
        {
            try
            {
                Bear bear = AddEditBear();
                _dataService?.Animals?.Mammals?.Bears?.Add(bear);
                Console.WriteLine("Bear with name: {0} has been added to a list of bears", bear.Name);
            }
            catch
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 12);
            }
        }

        /// <summary>
        /// Deletes a bear.
        /// </summary>
        private void DeleteBear()
        {
            try
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 13);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Bear? bear = (Bear?)(_dataService?.Animals?.Mammals?.Bears
                    ?.FirstOrDefault(b => b is not null && string.Equals(b.Name, name)));
                if (bear is not null)
                {
                    _dataService?.Animals?.Mammals?.Bears?.Remove(bear);
                    Console.WriteLine("Bear with name: {0} has been deleted from a list of bears", bear.Name);
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
        /// Edits an existing bear after choice made.
        /// </summary>
        private void EditBearMain()
        {
            try
            {
                ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 16);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Bear? bear = (Bear?)(_dataService?.Animals?.Mammals?.Bears
                    ?.FirstOrDefault(b => b is not null && string.Equals(b.Name, name)));
                if (bear is not null)
                {
                    Bear bearEdited = AddEditBear();
                    bear.Copy(bearEdited);
                    ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 17);
                    bear.Display();
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
        /// Adds/edit specific bear.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Bear AddEditBear()
        {
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 20);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 21);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 22);
            string? kindOf = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 23);
            string? pawSizeAsString = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 24);
            string? goodSenseOfSmell = Console.ReadLine();
            ScreenDefinitionService.ShowLine(ScreenDefinitionJson, 25);
            string? sharpnessOfTheClaws = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (kindOf is null)
            {
                throw new ArgumentNullException(nameof(kindOf));
            }
            if (pawSizeAsString is null)
            {
                throw new ArgumentNullException(nameof(pawSizeAsString));
            }
            if (goodSenseOfSmell is null)
            {
                throw new ArgumentNullException(nameof(goodSenseOfSmell));
            }
            if (sharpnessOfTheClaws is null)
            {
                throw new ArgumentNullException(nameof(sharpnessOfTheClaws));
            }

            int age = Int32.Parse(ageAsString);
            int pawSize = Int32.Parse(pawSizeAsString);

            Bear bear = new Bear(name, age, kindOf, pawSize, goodSenseOfSmell, sharpnessOfTheClaws)
            {
                PawSize = pawSize,
                GoodSenseOfSmeel = goodSenseOfSmell,
                SharpnessOfTheClaws = sharpnessOfTheClaws
            };

            return bear;
        }

        #endregion // Private Methods
    }
}
