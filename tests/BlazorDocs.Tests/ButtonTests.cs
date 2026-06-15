using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Xunit;
using BlazorDocs.UI;

public class ButtonTests : BunitContext
{
    [Fact]
    public void Renders_child_content()
    {
        var cut = Render<Button>(p => p.AddChildContent("Click me"));
        Assert.Contains("Click me", cut.Find("button.bd-btn").TextContent);
    }

    [Fact]
    public void Fires_OnClick()
    {
        var clicked = false;
        var cut = Render<Button>(p => p
            .Add(b => b.OnClick, EventCallback.Factory.Create<MouseEventArgs>(this, _ => clicked = true))
            .AddChildContent("Go"));
        cut.Find("button").Click();
        Assert.True(clicked);
    }

    [Fact]
    public void Disabled_true_renders_disabled_attribute()
    {
        var cut = Render<Button>(p => p
            .Add(b => b.Disabled, true)
            .AddChildContent("Disabled"));
        var button = cut.Find("button");
        Assert.True(button.HasAttribute("disabled"));
    }

    [Fact]
    public void Disabled_false_omits_disabled_attribute()
    {
        var cut = Render<Button>(p => p
            .Add(b => b.Disabled, false)
            .AddChildContent("Enabled"));
        var button = cut.Find("button");
        Assert.False(button.HasAttribute("disabled"));
    }
}
