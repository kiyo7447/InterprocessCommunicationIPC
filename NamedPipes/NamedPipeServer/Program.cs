using System;
using System.IO.Pipes;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// サーバーサイド
using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "testpipe", PipeDirection.In))
{
    Console.WriteLine("サーバーに接続中...");
    pipeClient.Connect();

    using (System.IO.StreamReader sr = new System.IO.StreamReader(pipeClient))
    {
        string temp;
        while ((temp = sr.ReadLine()) != null)
        {
            Console.WriteLine("受信: {0}", temp);
        }
    }
}

Console.WriteLine("クライアントが終了しました。");