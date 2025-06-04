using System.Collections.Generic;
using System.Threading.Tasks;
using HealthChecker.Data;
using HealthChecker.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class CategoryRepositoryTests
{
    private readonly CategoryRepository _repo;
    private readonly Mock<ILogger<CategoryRepository>> _loggerMock = new();

    public CategoryRepositoryTests()
    {
        _repo = new CategoryRepository(_loggerMock.Object);
    }

    [Fact]
    public async Task ListAsync_ReturnsList()
    {
        var result = await _repo.ListAsync();
        Assert.NotNull(result);
        Assert.IsType<List<Category>>(result);
    }

    [Fact]
    public async Task SaveAndGetAndDeleteItemAsync_Works()
    {
        var cat = new Category { Title = "Test", Color = "#fff" };
        int id = await _repo.SaveItemAsync(cat);
        Assert.True(id > 0);

        var fetched = await _repo.GetAsync(id);
        Assert.NotNull(fetched);
        Assert.Equal("Test", fetched.Title);

        int deleted = await _repo.DeleteItemAsync(cat);
        Assert.True(deleted >= 0);
    }

    [Fact]
    public async Task DropTableAsync_DoesNotThrow()
    {
        await _repo.DropTableAsync();
    }
}