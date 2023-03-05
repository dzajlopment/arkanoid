using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Editor : MonoBehaviour {
    private void Awake() {
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private static readonly string[] Names = {"one", "two", "three", "four", "five", "six"};
    
    public void CreateLevel(uint idx) {
        if (idx > Names.Length) return;
        Helpers.Data.LevelPersist = new Level(false, 0, Names[idx], Boosters.Default, new List<BrickData>());
        SceneManager.LoadScene("LevelEditorScreen");
    }
}
