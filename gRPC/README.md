# プロジェクトの作成から実行まで。
```powershell
# サーバ側
dotnet new -l
dotnet new webapi -n gRPCServer
cd gRPCServer
dotnet build && dotnet run
# クライアント側
dotnet new console -o gRPCClient
cd WgRPClient
dotnet build && dotnet run
```
