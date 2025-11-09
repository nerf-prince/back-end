namespace BackEnd.Services;

public interface ITopicProducer
{
    Task SendAsync(string message);
    Task SendAsync(object message);
}
