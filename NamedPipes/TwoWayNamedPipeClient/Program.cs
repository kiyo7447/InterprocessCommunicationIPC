using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// クライアントサイド
using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut))
        {
            Console.WriteLine("サーバーに接続中...");
            pipeClient.Connect();

            using (StreamWriter sw = new StreamWriter(pipeClient))
            using (StreamReader sr = new StreamReader(pipeClient))
            {
                sw.AutoFlush = true;

                while (true)
                {
                    Console.Write("サーバーに送るメッセージを入力してください: ");
                    string messageToServer = Console.ReadLine();

                    sw.WriteLine(messageToServer);

                    string messageFromServer = sr.ReadLine();
                    Console.WriteLine($"サーバーから受信: {messageFromServer}");

                    if (messageToServer == "終了")
                    {
                        break;
                    }
                }
            }
        }

        Console.WriteLine("クライアントが終了しました。");
