using System;
using System.IO.MemoryMappedFiles;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// メモリマップトファイルを作成
using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("testmap", 4096))
{
    // メモリマップトファイルのビューを作成
    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
    {
        // データを書き込む
        byte[] data = Encoding.UTF8.GetBytes("Hello, world!");
        accessor.WriteArray(0, data, 0, data.Length);

    }
    //何かキーを押すまで待機
    Console.ReadKey();
}

