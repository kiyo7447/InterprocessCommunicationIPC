using System;
using System.IO;
using System.IO.Pipes;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// サーバーサイド
using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe"))
{
    Console.WriteLine("NamedPipeServer がクライアントの接続を待っています...");
    pipeServer.WaitForConnection();

    Console.WriteLine("クライアントが接続しました。");
    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(pipeServer))
    // using (StreamReader sr = new StreamReader(pipeServer))
    {
        sw.AutoFlush = true;
        
        sw.WriteLine("Hello, Named Pipe");

/*
        while (true)
        {
            string messageFromClient = sr.ReadLine();
            Console.WriteLine($"クライアントから受信: {messageFromClient}");

            string response = $"サーバーからの応答: {messageFromClient}";
            sw.WriteLine(response);

            if (messageFromClient == "終了")
            {
                break;
            }
        }
 */    
    }
}

Console.WriteLine("サーバーが終了しました。");

/*

using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe"))
{
    Console.WriteLine("NamedPipeServer がクライアントの接続を待っています...");
    pipeServer.WaitForConnection();

    Console.WriteLine("クライアントが接続しました。");
    using (StreamWriter sw = new StreamWriter(pipeServer))
    using (StreamReader sr = new StreamReader(pipeServer))
    {
        sw.AutoFlush = true;

        while (true)
        {
            string messageFromClient = sr.ReadLine();
            Console.WriteLine($"クライアントから受信: {messageFromClient}");

            string response = $"サーバーからの応答: {messageFromClient}";
            sw.WriteLine(response);

            if (messageFromClient == "終了")
            {
                break;
            }
        }
    }
}

Console.WriteLine("サーバーが終了しました。");

 */