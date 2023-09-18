using System;
using RabbitMQ.Client;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// プロデュサー（送信者）のコード
//var factory = new ConnectionFactory() { HostName = "localhost" };
// ↓ Dockerで別の認証情報を設定した場合、その情報が必要になる。
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

    string message = "Hello RabbitMQ!";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                         routingKey: "hello",
                         basicProperties: null,
                         body: body);
    Console.WriteLine($" [x] Sent {message}");
}