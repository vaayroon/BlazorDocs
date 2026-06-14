using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;
using BlazorDocs.UI;
using BlazorDocs.UI.Theming;

public class BlazorDocsProviderTests : BunitContext
{
    [Fact]
    public void Theme_Dark_renders_data_theme_dark_attribute()
    {
        var cut = Render<BlazorDocsProvider>(p => p
            .Add(b => b.Theme, ThemeMode.Dark));

        Assert.Equal("dark", cut.Find("[data-theme]").GetAttribute("data-theme"));
    }

    [Fact]
    public void Theme_Dark_cascades_BlazorDocsTheme_with_Mode_Dark()
    {
        BlazorDocsTheme? received = null;

        var cut = Render<BlazorDocsProvider>(p => p
            .Add(b => b.Theme, ThemeMode.Dark)
            .AddChildContent(builder =>
            {
                builder.OpenComponent<ThemeCaptureStub>(0);
                builder.AddComponentParameter(1, nameof(ThemeCaptureStub.OnThemeCaptured),
                    EventCallback.Factory.Create<BlazorDocsTheme>(this, t => received = t));
                builder.CloseComponent();
            }));

        Assert.NotNull(received);
        Assert.Equal(ThemeMode.Dark, received!.Mode);
    }
}

/// <summary>
/// Minimal Blazor component used in tests to capture the cascaded BlazorDocsTheme.
/// </summary>
file sealed class ThemeCaptureStub : ComponentBase
{
    [CascadingParameter] public BlazorDocsTheme? Theme { get; set; }

    [Parameter] public EventCallback<BlazorDocsTheme> OnThemeCaptured { get; set; }

    protected override void OnParametersSet()
    {
        if (Theme is not null)
            OnThemeCaptured.InvokeAsync(Theme);
    }
}
