using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ScoreManager
{
    private static string Path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/zip-file/arkanoid";

    private static void CheckForDirectory()
    {
        if (!Directory.Exists(Path)) {
            Directory.CreateDirectory(Path);
        }
    }

    public static List<ScoreRecord> GetScores()
    {
        CheckForDirectory();
        var fs = File.Open($"{Path}/scores", FileMode.OpenOrCreate);
        var sr = new StreamReader(fs);
        var list = new List<ScoreRecord>();

        while (!sr.EndOfStream)
        {
            var s = sr.ReadLine().Split(';');
            list.Add(new ScoreRecord(s[0], int.Parse(s[1])));
        }

        sr.Close();
        fs.Close();

        return list;
    }

    public static void SaveRecord(string name, int score)
    {
        CheckForDirectory();
        var fs = File.Open($"{Path}/scores", FileMode.Append);
        var sw = new StreamWriter(fs);

        sw.WriteLine($"{name};{score}");
        sw.Close();
        fs.Close();
    }

    public static void ClearRecords()
    {
        CheckForDirectory();
        var fs = File.Open($"{Path}/scores", FileMode.Create);
        fs.Close();
    }
}
