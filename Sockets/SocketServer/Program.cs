using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// サーバーサイド
// TCPソケットを作成
Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

// ローカルホストのポート5000にバインド
serverSocket.Bind(new IPEndPoint(IPAddress.Any, 5000));

// 接続待機開始
serverSocket.Listen(1);
Console.WriteLine("サーバーがクライアントの接続を待っています...");

// クライアントからの接続を受け入れる
Socket clientSocket = serverSocket.Accept();
Console.WriteLine("クライアントが接続しました。");

// メッセージを送信
byte[] message = Encoding.ASCII.GetBytes("Hello, Client!");
clientSocket.Send(message);

// ソケットを閉じる
clientSocket.Close();
serverSocket.Close();
