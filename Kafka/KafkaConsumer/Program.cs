using System;
using System.Threading;
using Confluent.Kafka;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "test-group",
    // Note: The AutoOffsetReset property determines the start offset in the event
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe("test-topic");

    CancellationTokenSource cts = new CancellationTokenSource();
    Console.CancelKeyPress += (_, e) =>
    {
        e.Cancel = true; // prevent the process from terminating.
        cts.Cancel();
    };

    try
    {
        while (true)
        {
            try
            {
                var cr = consumer.Consume(cts.Token);
                Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
            }
            catch (ConsumeException e)
            {
                Console.WriteLine($"Error occurred: {e.Error.Reason}");
            }
        }
    }
    catch (OperationCanceledException)
    {
        // Ensure the consumer leaves the group cleanly and final offsets are committed.
        Console.WriteLine("Closing consumer.");
        consumer.Close();
    }

    // while (true)
    // {
    //     var result = consumer.Consume();

    //     if (result.IsPartitionEOF)
    //     {
    //         Console.WriteLine($"Reached end of topic {result.Topic}, partition {result.Partition}, offset {result.Offset}.");
    //         continue;
    //     }

    //     Console.WriteLine($"Received message: {result.Value}");
    // }
}
