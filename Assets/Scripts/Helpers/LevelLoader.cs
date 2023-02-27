using System;
using System.Collections.Generic;
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
    /// Save level to disk.
    /// </summary>
    public static void SaveLevel(Level level) {
        FileStream fs = new FileStream($"{Path}/levels/{level.Name.ToLower()}", FileMode.OpenOrCreate);
        BinaryWriter writer = new BinaryWriter(fs);
        writer.Write(level.Number);
        writer.Write(level.Name);
        writer.Write((int)level.Boosters);
        writer.Write(level.Bricks.Count);
        foreach (var i in level.Bricks) {
            writer.Write((byte)i.Colour);
            writer.Write(i.Left);
            writer.Write(i.Top);
        }
        writer.Close();
    }

    /// <summary>
    /// Load level from byte array.
    /// </summary>
    private static Level LoadLevel(Stream stream) {
        BinaryReader reader = new BinaryReader(stream);
        byte number = reader.ReadByte();
        String name = reader.ReadString();
        Boosters boosters = (Boosters)reader.ReadInt32();
        byte bcount = reader.ReadByte();
        List<BrickData> bricks = new List<BrickData>();
        for (int i = 0; i < bcount; i++) {
            byte bcolour = reader.ReadByte();
            int bx = reader.ReadInt32();
            int by = reader.ReadInt32();
            bricks.Add(new BrickData((BrickColour)bcolour, bx, by));
        }
        Level level = new Level(
            number != 0,
            number,
            name,
            boosters,
            bricks
        );

        stream.Close();
        return level;
    }

    /// <summary>
    /// Load official level with specified `number`.
    /// </summary>
    public static Level LoadOfficialLevel(int number) {
        var file = Resources.Load<TextAsset>($"Assets/Levels/level{number}");
        return LoadLevel(new MemoryStream(file.bytes));
    }

    /// <summary>
    /// Load custom level with specified `name`.
    /// </summary>
    public static Level LoadCustomLevel(string name) {
        var fs = File.Open($"{Path}/levels/{name}", FileMode.Open);
        return LoadLevel(fs);
    }
}