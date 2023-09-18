# 

## プロデュサー（送信側）の作成）
```powershell
dotnet new console -n Producer
cd Producer
dotnet add package RabbitMQ.Client
dotnet build && dotnet run

```

## コンシュマー（受信側）の作成
```powershell
dotnet new console -n Consumer
cd Consumer
dotnet add package RabbitMQ.Client
dotnet build && dotnet run

```

## RabbitMQのコンテナをビルドして、起動する。
```powershell
docker build -t rabbitmq-image .
docker run -d --rm --hostname rabbitms --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq-image
```

## 実際は、公式のRabbitMQイメージを使用する方が一般的です。（公式）
```powershell
docker run -d --rm  --hostname rabbitmq --name rabbitmq-official -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```

