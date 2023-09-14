namespace SampleHierarchies.Gui;

/// <summary>
/// Abstract base class for a screen.
/// </summary>
public abstract class Screen
{
    #region Public Methods

    /// <summary>
    /// Show the screen.
    /// </summary>

    public virtual string ScreenDefinitionJson { get; set; } = null!;

    public virtual void Show()
    {
        Console.WriteLine("Showing screen");
    }

    #endregion // Public Methods
}
