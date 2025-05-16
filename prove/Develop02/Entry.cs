using System;
using System.IO;

public class Entry
{
    private string entryText = "";  // 사용자가 쓴 글을 임시로 저장하는 변수
    private string fileName = "myEntry.txt";

    // 사용자가 입력한 글을 저장
    public void WriteEntry()
    {
        Console.WriteLine("오늘의 일기를 입력하세요 (입력을 마치려면 빈 줄에서 Enter):");

        string line;
        entryText = ""; // 초기화
        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                break;
            entryText += line + Environment.NewLine;
        }
    }

    // 글을 txt 파일로 저장
    public void SaveEntry()
    {
        using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
        {
            outputFile.WriteLine("=== 새 일기 (" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + ") ===");
            outputFile.WriteLine(entryText);
            outputFile.WriteLine(); // 줄바꿈
        }
        Console.WriteLine("일기가 저장되었습니다.");
    }

    // txt 파일에서 글을 불러옴
    public void LoadEntry()
    {
        if (File.Exists(fileName))
        {
            Console.WriteLine("저장된 일기:");
            string content = File.ReadAllText(fileName);
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("저장된 일기가 없습니다.");
        }
    }
}