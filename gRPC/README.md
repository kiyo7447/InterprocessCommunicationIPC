# プロジェクトの作成から実行まで。
```powershell
# サーバ側
dotnet new -l
dotnet new grpc -n gRPCServer
cd gRPCServer
dotnet build && dotnet run
# クライアント側
dotnet new console -o gRPCClient
cd gRPCClient

# gRPC クライアントを.NETで作成するために必要なパッケージです。
dotnet add package Grpc.Net.Client
# Protocol Buffers（Protobuf）のシリアライゼーション・デシリアライゼーションを担当します。
dotnet add package Google.Protobuf
# .proto ファイルから C# コードを生成するために使用されます。
# つまり、自分で .proto ファイルをコンパイルしてクライアント（またはサーバー）コードを生成する場合は、このパッケージが必要です。
dotnet add package Grpc.Tools

mkdir Protos
# .protoファイルをProtosフォルダにコピー
# .csprojに以下を追加
# <ItemGroup>
#   <Protobuf Include="Protos\*.proto" GrpcServices="Client" />
# </ItemGroup>

dotnet build && dotnet run
```
