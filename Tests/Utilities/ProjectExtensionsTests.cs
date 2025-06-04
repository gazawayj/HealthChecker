using HealthChecker.Models;
using HealthChecker.Utilities;
using Xunit;

public class ProjectExtensionsTests
{
    [Fact]
    public void IsNullOrNew_ReturnsTrue_WhenProjectIsNull()
    {
        Project? project = null;
        Assert.True(ProjectExtentions.IsNullOrNew(project));
    }

    [Fact]
    public void IsNullOrNew_ReturnsTrue_WhenProjectIdIsZero()
    {
        var project = new Project { ID = 0 };
        Assert.True(project.IsNullOrNew());
    }

    [Fact]
    public void IsNullOrNew_ReturnsFalse_WhenProjectIdIsNonZero()
    {
        var project = new Project { ID = 5 };
        Assert.False(project.IsNullOrNew());
    }
}