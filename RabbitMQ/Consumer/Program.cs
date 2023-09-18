using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// 認証を入れる対応
//var factory = new ConnectionFactory() { HostName = "localhost" };
// ↓
var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "admin",  // ここにユーザー名を設定
    Password = "admin"   // ここにパスワードを設定
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Received {message}");
    };
    channel.BasicConsume(queue: "hello",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}