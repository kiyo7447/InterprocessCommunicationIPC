using System;
using System.IO.Pipes;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// クライアントサイド
using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe"))
{
    Console.WriteLine("NamedPipeServer がクライアントの接続を待っています...");
    pipeServer.WaitForConnection();

    Console.WriteLine("クライアントが接続しました。");
    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(pipeServer))
    {
        sw.AutoFlush = true;
        sw.WriteLine("Hello, Named Pipe");
    }
}

Console.WriteLine("サーバーが終了しました。");
