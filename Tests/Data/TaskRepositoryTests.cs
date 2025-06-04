using System.Collections.Generic;
using System.Threading.Tasks;
using HealthChecker.Data;
using HealthChecker.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class TaskRepositoryTests
{
    private readonly TaskRepository _repo;
    private readonly Mock<ILogger<TaskRepository>> _loggerMock = new();

    public TaskRepositoryTests()
    {
        _repo = new TaskRepository(_loggerMock.Object);
    }

    [Fact]
    public async Task ListAsync_ReturnsList()
    {
        var result = await _repo.ListAsync();
        Assert.NotNull(result);
        Assert.IsType<List<ProjectTask>>(result);
    }

    [Fact]
    public async Task ListAsync_ByProjectId_ReturnsList()
    {
        var result = await _repo.ListAsync(1);
        Assert.NotNull(result);
        Assert.IsType<List<ProjectTask>>(result);
    }

    [Fact]
    public async Task SaveAndGetAndDeleteItemAsync_Works()
    {
        var task = new ProjectTask { Title = "Test", IsCompleted = false, ProjectID = 1 };
        int id = await _repo.SaveItemAsync(task);
        Assert.True(id > 0);

        var fetched = await _repo.GetAsync(id);
        Assert.NotNull(fetched);
        Assert.Equal("Test", fetched.Title);

        int deleted = await _repo.DeleteItemAsync(task);
        Assert.True(deleted >= 0);
    }

    [Fact]
    public async Task DropTableAsync_DoesNotThrow()
    {
        await _repo.DropTableAsync();
    }
}