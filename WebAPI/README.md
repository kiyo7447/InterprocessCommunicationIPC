# プロジェクトの作成から実行まで。
```powershell
# サーバ側
dotnet new -l
dotnet new webapi -n WebAPIServer
cd WebAPIServer
dotnet build && dotnet run
# クライアント側
dotnet new console -o WebAPIClient
cd WebAPIClient
dotnet build && dotnet run
```
