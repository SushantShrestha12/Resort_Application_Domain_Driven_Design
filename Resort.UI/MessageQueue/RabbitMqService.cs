using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

namespace Resort.UI.MessageQueue;

public class RabbitMqService
{
    private readonly IModel _channel;

    public RabbitMqService()
    {
        var factory = new ConnectionFactory()
        { 
            UserName = "guest",
            Password = "guest"
        };

        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
    }

    public void PublishMessage(string message, string queueName)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish("", queueName,  null,  body);
    }

    public void ConsumeMessages(string queueName, Action<string> onMessageReceived)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body;
            var messageBytes = body.ToArray();
            var message = Encoding.UTF8.GetString(messageBytes);
            onMessageReceived(message);
        };

        _channel.BasicConsume(queueName, true, consumer);
    }

    // public void Dispose()
    // {
    //     _channel?.Dispose();
    //     _connection?.Dispose();
    // }
}