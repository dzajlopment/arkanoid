using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class for storing game state.
/// </summary>
public static class GameState {
    /// <summary>
    /// Currently played level. Equals to zero if outside the game.
    /// </summary>
    public static int Level = 0;

    /// <summary>
    /// Score.
    /// </summary>
    public static int Score = 0;

    /// <summary>
    /// Remaining lives.
    /// </summary>
    public static byte Lives = 3;

    /// <summary>
    /// Set all values to their initial values. Used when starting a new game.
    /// </summary>
    public static void Init() {
        Level = 1;
        Score = 0;
        Lives = 3;
    }
}
