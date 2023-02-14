using System;
using System.Collections.Generic;

/// <summary>
/// Available boosters.
/// </summary>
[Flags]
public enum Boosters {
    // TODO
    Default = 1 << 31,
}

public enum BrickColour {
    White,
    Orange,
    LightBlue,
    Green,
    Red,
    Blue,
    Purple,
    Yellow,
    Silver,
    Gold,
}

/// <summary>
/// Contains position and colour of a single brick.
/// </summary>
public class BrickData {
    BrickColour Colour;
    int Left;
    int Top;
}

/// <summary>
/// Level loaded with `LevelLoader.LoadLevel()`.
/// </summary>
public class Level {
    /// <summary>
    /// Determines if this is official level.
    /// </summary>
    public bool Official { get; }
    /// <summary>
    /// Level number. Applies only for official levels.
    /// Equals to 0 for custom level.
    /// </summary>
    public byte Number { get; }
    /// <summary>
    /// Level name.
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// Determines boosters available in this level.
    /// </summary>
    public Boosters Boosters { get; }
    /// <summary>
    /// Contains data of all bricks in this level.
    /// </summary>
    public List<BrickData> Bricks { get; }

    public Level(bool official, byte number, string name, Boosters boosters, List<BrickData> bricks) {
        return new Level {
            Official = official,
            Number = number,
            Name = name,
            Boosters = boosters,
            Bricks = bricks,
        };
    }
}