using System;
using Confluent.Kafka;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "test_group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe("test_topic");

    while (true)
    {
        var result = consumer.Consume();

        if (result.IsPartitionEOF)
        {
            Console.WriteLine($"Reached end of topic {result.Topic}, partition {result.Partition}, offset {result.Offset}.");
            continue;
        }

        Console.WriteLine($"Received message: {result.Value}");
    }
}
