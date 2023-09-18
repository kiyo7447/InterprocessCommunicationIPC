using System;
using System.IO.MemoryMappedFiles;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// 既存のメモリマップトファイルを開く
using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("testmap"))
{
    // メモリマップトファイルのビューを作成
    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
    {
        // データを読み取る
        byte[] data = new byte[13];  // "Hello, world!"の長さ
        accessor.ReadArray(0, data, 0, data.Length);
        Console.WriteLine(Encoding.UTF8.GetString(data));
    }
}