using Amazon.SimpleNotificationService;
using Newtonsoft.Json;

namespace BackEnd.Services;

public class SnsProducer(string topicArn) : ITopicProducer
{
    private readonly AmazonSimpleNotificationServiceClient _client = new();

    public async Task SendAsync(string message)
    {
        await _client.PublishAsync(new()
        {
            Message = message,
            TopicArn = topicArn,
        });
    }

    public async Task SendAsync(object message)
    {
        await SendAsync(
            JsonConvert.SerializeObject(message)
        );
    }
}
