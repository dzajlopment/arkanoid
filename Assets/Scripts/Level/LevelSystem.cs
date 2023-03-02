using UnityEngine;

/// <summary>
/// A class for managing currently played level.
/// </summary>
public class LevelSystem : MonoBehaviour {
    public int Level { get; private set; } = 1;

    public void Advance() {
        Level++;
    }
}