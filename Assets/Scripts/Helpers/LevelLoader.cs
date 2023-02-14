using System;
using System.IO;
using UnityEngine;

/// <summary>
/// A class which handles loading levels into more convenient form.
/// </summary>
public static class LevelLoader {
    /// <summary>
    /// A path to application data directory.
    /// </summary>
    private static string Path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/zip-file/arkanoid";

    /// <summary>
    /// Load level from byte array.
    /// </summary>
    private static Level LoadLevel(byte[] bytes) {
        // TODO
        return new Level();
    }

    /// <summary>
    /// Load official level with specified `number`.
    /// </summary>
    public static Level LoadOfficialLevel(int number) {
        var file = Resources.Load<TextAsset>($"Assets/Levels/level{number}");
        return LoadLevel(file.bytes);
    }

    /// <summary>
    /// Load custom level with specified `name`.
    /// </summary>
    public static Level LoadCustomLevel(string name) {
        var fs = File.Open($"{Path}/levels/{name}", FileMode.Open);
        var len = fs.Length;
        var bytes = new byte[len];
        fs.Read(bytes, 0, (int)len);
        fs.Close();
        return LoadLevel(bytes);
    }
}