using System.Collections.Generic;
using System.Threading.Tasks;
using HealthChecker.Data;
using HealthChecker.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class TagRepositoryTests
{
    private readonly TagRepository _repo;
    private readonly Mock<ILogger<TagRepository>> _loggerMock = new();

    public TagRepositoryTests()
    {
        _repo = new TagRepository(_loggerMock.Object);
    }

    [Fact]
    public async Task ListAsync_ReturnsList()
    {
        var result = await _repo.ListAsync();
        Assert.NotNull(result);
        Assert.IsType<List<Tag>>(result);
    }

    [Fact]
    public async Task ListAsync_ByProjectId_ReturnsList()
    {
        var result = await _repo.ListAsync(1);
        Assert.NotNull(result);
        Assert.IsType<List<Tag>>(result);
    }

    [Fact]
    public async Task SaveAndGetAndDeleteItemAsync_Works()
    {
        var tag = new Tag { Title = "Test", Color = "#fff" };
        int id = await _repo.SaveItemAsync(tag);
        Assert.True(id > 0);

        var fetched = await _repo.GetAsync(id);
        Assert.NotNull(fetched);
        Assert.Equal("Test", fetched.Title);

        int deleted = await _repo.DeleteItemAsync(tag);
        Assert.True(deleted >= 0);
    }

    [Fact]
    public async Task SaveAndDeleteItemAsync_WithProject_Works()
    {
        var tag = new Tag { Title = "Test2", Color = "#000" };
        int id = await _repo.SaveItemAsync(tag, 1);
        Assert.True(id >= 0);

        int deleted = await _repo.DeleteItemAsync(tag, 1);
        Assert.True(deleted >= 0);
    }

    [Fact]
    public async Task DropTableAsync_DoesNotThrow()
    {
        await _repo.DropTableAsync();
    }
}