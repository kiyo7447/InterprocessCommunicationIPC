# Named Pipes Version 1
## プロジェクトの作成から実行まで。
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
# Named Pipes Version 2
## プロジェクトの作成から実行まで。
```powershell
# サーバサイド
dotnet new console -o TwoWayNamedPipeServer
cd TwoWayNamedPipeServer
dotnet build && dotnet run
# クライアントサイド
dotnet new console -o TwoWayNamedPipeClient
cd TwoWayNamedPipeClient
dotnet build && dotnet run
```
# エラー
## 日本語が文字化けする。
```powershell
# サーバーサイド（エンコーディング指定）
using (StreamWriter sw = new StreamWriter(pipeServer, System.Text.Encoding.UTF8))
using (StreamReader sr = new StreamReader(pipeServer, System.Text.Encoding.UTF8))
{
    // 以前のコード
}
# クライアントサイド（エンコーディング指定）
using (StreamWriter sw = new StreamWriter(pipeClient, System.Text.Encoding.UTF8))
using (StreamReader sr = new StreamReader(pipeClient, System.Text.Encoding.UTF8))
{
    // 以前のコード
}
```
しかし、これは処理がうまく動かなかった。
