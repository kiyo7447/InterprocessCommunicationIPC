# プロジェクトの作成から実行まで。
```powershell
# 書き込み側
dotnet new console -o SocketServer
cd SocketServer
dotnet build && dotnet run
# 読み込み側
dotnet new console -o SocketClient
cd SocketClient
dotnet build && dotnet run
```
