using System;
using Confluent.Kafka;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    for (int i = 0; i < 100; ++i)
    {
        var messageValue = $"メッセージ {i}";
        try
        {

            producer.Produce("test-topic", new Message<Null, string> { Value = messageValue }, deliveryReport =>
             {
                 if (deliveryReport.Error.Code == ErrorCode.NoError)
                 {
                     Console.WriteLine($"メッセージを送信しました: {deliveryReport.Value}");
                 }
                 else
                 {
                     Console.WriteLine($"エラーが発生しました: {deliveryReport.Error.Reason}");
                 }
             });
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"エラーが発生しました: {e.Error.Reason}");
        }
    }

    producer.Flush(TimeSpan.FromSeconds(10));
}
