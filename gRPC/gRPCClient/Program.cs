using System;
using Grpc.Net.Client;
using System.Reflection;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// オブジェクトからネームスペースを取得
// 空のネームスペースを表示となった
Console.WriteLine(typeof(Program).Namespace);

MethodBase method = MethodBase.GetCurrentMethod();
Type type = method.DeclaringType;
string namespaceName = type.Namespace;
// 空のネームスペースを表示となった
Console.WriteLine("現在のネームスペース: " + namespaceName);

// クライアントサイド
using var channel = GrpcChannel.ForAddress("http://localhost:5010");
var client = new gRPCServer.Hello.HelloClient(channel);

var reply = client.SayHello(new gRPCServer.HelloRequest { Name = "World" });
Console.WriteLine("Greeting: " + reply.Message);
