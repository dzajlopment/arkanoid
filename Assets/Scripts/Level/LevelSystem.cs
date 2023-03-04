using UnityEngine;

/// <summary>
/// A class for managing currently played level.
/// </summary>
public class LevelSystem : MonoBehaviour {
    public LevelSystem Instance { get; private set; }
    public int Level { get; private set; } = 1;

    public void Awake() {
        Instance = this;
    }

    public void Advance() {
        Level++;
    }
}