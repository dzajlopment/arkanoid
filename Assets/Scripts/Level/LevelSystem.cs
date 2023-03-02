using UnityEngine;

/// <summary>
/// A class for managing currently played level.
/// </summary>
public static class LevelSystem {
    public static int Level { get; private set; } = 1;

    public static void Advance() {
        Level++;
    }
}