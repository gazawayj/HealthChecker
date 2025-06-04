using System.Collections.Generic;
using System.Threading.Tasks;
using HealthChecker.Data;
using HealthChecker.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class ProjectRepositoryTests
{
    private readonly ProjectRepository _repo;
    private readonly Mock<ILogger<ProjectRepository>> _loggerMock = new();
    private readonly TaskRepository _taskRepo;
    private readonly TagRepository _tagRepo;

    public ProjectRepositoryTests()
    {
        _taskRepo = new TaskRepository(new Mock<ILogger<TaskRepository>>().Object);
        _tagRepo = new TagRepository(new Mock<ILogger<TagRepository>>().Object);
        _repo = new ProjectRepository(_taskRepo, _tagRepo, _loggerMock.Object);
    }

    [Fact]
    public async Task ListAsync_ReturnsList()
    {
        var result = await _repo.ListAsync();
        Assert.NotNull(result);
        Assert.IsType<List<Project>>(result);
    }

    [Fact]
    public async Task SaveAndGetAndDeleteItemAsync_Works()
    {
        var proj = new Project { Name = "Test", Description = "Desc", Icon = "icon", CategoryID = 1 };
        int id = await _repo.SaveItemAsync(proj);
        Assert.True(id > 0);

        var fetched = await _repo.GetAsync(id);
        Assert.NotNull(fetched);
        Assert.Equal("Test", fetched.Name);

        int deleted = await _repo.DeleteItemAsync(proj);
        Assert.True(deleted >= 0);
    }

    [Fact]
    public async Task DropTableAsync_DoesNotThrow()
    {
        await _repo.DropTableAsync();
    }
}