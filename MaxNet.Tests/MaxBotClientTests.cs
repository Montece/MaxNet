using MaxNet.Client;
using MaxNet.Options;
using RichardSzalay.MockHttp;
using Xunit;

namespace MaxNet.Tests;

public sealed class MaxBotClientTests
{
    [Fact]
    public async Task MeAsync_ReturnsCorrectModel()
    {
        using var mock = new MockHttpMessageHandler();

        var fakeResponse = """
                           
                               {
                                 "user_id": 123456,
                                 "first_name": "My Bot",
                                 "last_name": "TheBot",
                                 "username": "my_bot",
                                 "is_bot": true,
                                 "last_activity_time": 1737500130100,
                                 "description": "Описание",
                                 "avatar_url": "https://.../small.jpg",
                                 "full_avatar_url": "https://.../large.jpg",
                                 "commands": [
                                    { "name": "cmd1", "description": "desc1" }
                                 ]
                               }
                           """;

        mock.When("https://api.max.ru/me").Respond("application/json", fakeResponse);

        var http = mock.ToHttpClient();
        var options = new MaxBotClientOptions("token");
        var client = new MaxBotClient(http, options);

        var info = await client.Bots.GetMeAsync();

        Assert.Equal(123456, info.UserId);
        Assert.Equal("My Bot", info.FirstName);
        Assert.True(info.IsBot);
        Assert.Equal("cmd1", info.Commands?.First().Name);
    }
}