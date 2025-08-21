using Xunit;

namespace MaxNet.Tests;

using Guard = Utility.Guard;

public class GuardTests
{
    [Fact]
    public void NotNull_ShouldThrowArgumentNullException_WhenDataIsNull()
    {
        var paramName = "paramName";
        object? data = null;

        Assert.Throws<ArgumentNullException>(() => Guard.NotNull(paramName, data));
    }

    [Fact]
    public void NotNull_ShouldNotThrow_WhenDataIsNotNull()
    {
        var paramName = "paramName";
        var data = new object();

        var exception = Record.Exception(() => Guard.NotNull(paramName, data));
        Assert.Null(exception);
    }

    [Fact]
    public void NotNullOrEmpty_ShouldThrowArgumentNullException_WhenTextIsNull()
    {
        var paramName = "paramName";
        string? text = null;

        Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(paramName, text));
    }

    [Fact]
    public void NotNullOrEmpty_ShouldThrowArgumentNullException_WhenTextIsEmpty()
    {
        var paramName = "paramName";
        var text = string.Empty;

        Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(paramName, text));
    }

    [Fact]
    public void NotNullOrEmpty_ShouldNotThrow_WhenTextIsNotNullOrEmpty()
    {
        var paramName = "paramName";
        var text = "text";

        var exception = Record.Exception(() => Guard.NotNullOrEmpty(paramName, text));
        Assert.Null(exception);
    }
}