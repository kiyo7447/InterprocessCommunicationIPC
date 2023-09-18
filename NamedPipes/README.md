# プロジェクトの作成から実行まで。
```powershell
# サーバサイド
dotnet new console -o NamedPipeServer
cd NamedPipeServer
dotnet build && dotnet run
# クライアントサイド
dotnet new console -o NamedPipeClient
cd NamedPipeClient
dotnet build && dotnet run
```

# 処理性能を試す
```powershell
# サーバサイド
dotnet run repeat
# クライアントサイド
dotnet run loadtest
```
