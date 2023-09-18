using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// クライアントサイド
// TCPソケットを作成
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // サーバーに接続
        clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 5000));
        Console.WriteLine("サーバーに接続しました。");

        // データを受け取る
        byte[] buffer = new byte[1024];
        int received = clientSocket.Receive(buffer);
        string message = Encoding.ASCII.GetString(buffer, 0, received);
        Console.WriteLine($"受信メッセージ: {message}");

        // ソケットを閉じる
        clientSocket.Close();
        