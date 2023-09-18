# プロジェクトの作成から実行まで。
```powershell
# 書き込み側
dotnet new console -o WriteMappedFile
cd WriteMappedFile
dotnet build && dotnet run
# 読み込み側
dotnet new console -o ReadMappedFile
cd ReadMappedFile
dotnet build && dotnet run
```

## References
このエラーメッセージによれば、指定されたメモリマップトファイル（Memory-Mapped File）が見つからないという内容です。以下にいくつか考慮すべきポイントを挙げます。

1. **プロセス間での共有**: メモリマップトファイルは通常、作成したプロセスでしかアクセスできません。しかし、他のプロセスからもアクセス可能なメモリマップトファイルを作成することもあります。その場合、`Global\`プレフィックスを使用して作成およびアクセスする必要があります。例：`Global\testmap`

⇒これは嘘です。

2. **名前の一致**: `MemoryMappedFile.CreateNew()`で指定した名前と`MemoryMappedFile.OpenExisting()`で指定する名前が完全に一致している必要があります。

3. **ライフタイム**: メモリマップトファイルが作成されている間に読み取りを行う必要があります。メモリマップトファイルが破棄された或いはプロセスが終了した場合、そのファイルはもうアクセスできなくなります。

⇒これは注意点。

4. **アクセス権限**: `MemoryMappedFileRights`や`HandleInheritability`を指定する場合、これらが読み取り側と書き込み側で一致している必要があります。

5. **エラーチェック**: `MemoryMappedFile.OpenExisting`メソッドは、指定された名前のメモリマップトファイルが存在しない場合に`FileNotFoundException`をスローします。このメソッドを呼び出す前に、そのファイルが存在するかどうかを別途確認する方法も考慮できます。

上記のポイントに気を付けつつ、コードを確認してみてください。それでも問題が解決しない場合は、コードの詳細を共有いただけると、より具体的なアドバイスが可能です。

# 発生したエラー
## MemoryMappedFileのインスタンスがなくなると読み取り側でエラーが発生する。
```bash
```bash
Unhandled exception. System.IO.FileNotFoundException: Unable to find the specified file.
   at System.IO.MemoryMappedFiles.MemoryMappedFile.OpenCore(String mapName, HandleInheritability inheritability, Int32 desiredAccessRights, Boolean createOrOpen)
   at System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting(String mapName, MemoryMappedFileRights desiredAccessRights, HandleInheritability inheritability)
   at Program.<Main>$(String[] args) in C:\dev\GitHub\kiyo7447\ShardMemory\Memory-MappedFiles\ReadMappedFile\Program.cs:line 9
   ```
   