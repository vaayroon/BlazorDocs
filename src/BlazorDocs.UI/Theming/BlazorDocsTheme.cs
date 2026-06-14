namespace BlazorDocs.UI.Theming;

/// <summary>The two supported theme modes.</summary>
public enum ThemeMode
{
    Light,
    Dark
}

/// <summary>
/// Holds the active theme state cascaded by <see cref="BlazorDocsProvider"/>.
/// The <see cref="DataTheme"/> property maps the enum to the CSS data-theme attribute value.
/// </summary>
public class BlazorDocsTheme
{
    public ThemeMode Mode { get; set; } = ThemeMode.Light;

    /// <summary>Returns the CSS data-theme attribute value for the current mode.</summary>
    public string DataTheme => Mode == ThemeMode.Dark ? "dark" : "light";
}
