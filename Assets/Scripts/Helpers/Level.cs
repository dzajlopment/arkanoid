using System;
using System.Collections.Generic;

/// <summary>
/// Available boosters.
/// </summary>
[Flags]
public enum Boosters {
    ExtraBalls      = 1,
    WidePlatform    = 1 << 1,
    Laser           = 1 << 2,
    StrongBall      = 1 << 3,
    ExtraLife       = 1 << 4,
    CatchBall       = 1 << 5,
    SkipLevel       = 1 << 6,
    BottomBarrier   = 1 << 7,
    Default         = 1 << 31,
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
    public BrickColour Colour { get; }
    public int Left { get; }
    public int Top { get; }

    public BrickData(BrickColour colour, int left, int top) {
        Colour = colour;
        Left = left;
        Top = top;
    }
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
    /// Determines score value of silver brick.
    /// </summary>
    public int SilverBrickValue { get; }
    /// <summary>
    /// Contains data of all bricks in this level.
    /// </summary>
    public List<BrickData> Bricks { get; }

    public Level(bool official, byte number, string name, Boosters boosters, int silverBrickValue, List<BrickData> bricks) {
        Official = official;
        Number = number;
        Name = name;
        Boosters = boosters;
        SilverBrickValue = silverBrickValue;
        Bricks = bricks;
    }
}