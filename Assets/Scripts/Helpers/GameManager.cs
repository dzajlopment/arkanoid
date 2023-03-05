using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// A class for managing game state.
/// </summary>
public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public delegate void LevelCleared();
    public static event LevelCleared OnLevelCleared;

    public TextMeshProUGUI LifesText;
    public TextMeshProUGUI ScoreText;

    public int Level = 1;
    public int Lifes = 3;
    int Score = 0;
    int Counter = 1;

    bool Reached20k = false;
    bool Reached60k = false;

    public int BlueBricks;
    public int GreenBricks;
    public int LightBlueBricks;
    public int OrangeBricks;
    public int PurpleBricks;
    public int RedBricks;
    public int SilverBricks;
    public int WhiteBricks;
    public int YellowBricks;

    void Start() {
        RefreshLifesText();
        RefreshScoreText();
        DestroyBrick.OnBrickDestroyed += OnBrickDestroyed;
    }

    void Awake() {
        Instance = this;
    }

    public void AdvanceLevel() {
        Level++;
    }

    public void RefreshLifesText() {
        LifesText.text = $"Lifes: { Lifes }";
    }

    void RefreshScoreText() {
        ScoreText.text = $"Score: { Score }";
    }

    public void AddLife() {
        Lifes++;
        RefreshLifesText();
    }

    public void RemoveLife() {
        Lifes--;
        RefreshLifesText();
    }

    public void AddPoints(int points) {
        Score += points;

        if (Score >= 20000 && !Reached20k) {
            AddLife();
            Reached20k = true;
        }
        if (Score >= 60000 && !Reached60k) {
            AddLife();
            Reached60k = true;
        }

        if (Score / 60000 > Counter) {
            AddLife();
            Counter = Score / 60000;
        }

        if (Score >= 500 && Powerups.areEnoughPoints == false)
        {
            Powerups.areEnoughPoints = true;
        }
    }

    public void OnBrickDestroyed(BrickColour colour) {
        switch (colour) {
            case BrickColour.White:
                GameManager.Instance.AddPoints(50);
                WhiteBricks--;
                break;
            case BrickColour.Orange:
                GameManager.Instance.AddPoints(60);
                OrangeBricks--;
                break;
            case BrickColour.LightBlue:
                GameManager.Instance.AddPoints(70);
                LightBlueBricks--;
                break;
            case BrickColour.Green:
                GameManager.Instance.AddPoints(80);
                GreenBricks--;
                break;
            case BrickColour.Red:
                GameManager.Instance.AddPoints(90);
                RedBricks--;
                break;
            case BrickColour.Blue:
                GameManager.Instance.AddPoints(100);
                BlueBricks--;
                break;
            case BrickColour.Purple:
                GameManager.Instance.AddPoints(110);
                PurpleBricks--;
                break;
            case BrickColour.Yellow:
                GameManager.Instance.AddPoints(120);
                YellowBricks--;
                break;
            case BrickColour.Silver:
            case BrickColour.Gold:
                break;
        }

        if (WhiteBricks == 0 &&
            OrangeBricks == 0 &&
            LightBlueBricks == 0 &&
            GreenBricks == 0 &&
            RedBricks == 0 &&
            BlueBricks == 0 &&
            PurpleBricks == 0 &&
            YellowBricks == 0 &&
            SilverBricks == 0
        ) {
            //Debug.Log("all bricks");
            AdvanceLevel();
            OnLevelCleared.Invoke();
        }
    }
}
