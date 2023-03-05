using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScene : MonoBehaviour {
    public GameObject BrickHolder;
    public GameObject BrickBlue;
    public GameObject BrickGold;
    public GameObject BrickGreen;
    public GameObject BrickLightBlue;
    public GameObject BrickOrange;
    public GameObject BrickPurple;
    public GameObject BrickRed;
    public GameObject BrickSilver;
    public GameObject BrickWhite;
    public GameObject BrickYellow;

    Level level;

    void Start() {
        GameManager.OnLevelCleared += RefreshLevel;
        RefreshLevel();
    }

    void RefreshLevel()
    {
        level = LevelLoader.LoadOfficialLevel(GameManager.Instance.Level);
        Dictionary<BrickColour, GameObject> brickPrefabs = new Dictionary<BrickColour, GameObject> {
        { BrickColour.White, BrickWhite },
        { BrickColour.Orange, BrickOrange },
        { BrickColour.LightBlue, BrickLightBlue },
        { BrickColour.Green, BrickGreen },
        { BrickColour.Red, BrickRed },
        { BrickColour.Blue, BrickBlue },
        { BrickColour.Purple, BrickPurple },
        { BrickColour.Yellow, BrickYellow },
        { BrickColour.Silver, BrickSilver },
        { BrickColour.Gold, BrickGold }
    };

        foreach (var brick in level.Bricks)
        {
            GameObject prefab;
            if (brickPrefabs.TryGetValue(brick.Colour, out prefab))
            {
                GameObject obj = Instantiate(prefab, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                obj.transform.SetParent(BrickHolder.transform);

                switch (brick.Colour)
                {
                    case BrickColour.White:
                        GameManager.Instance.WhiteBricks++;
                        break;
                    case BrickColour.Orange:
                        GameManager.Instance.OrangeBricks++;
                        break;
                    case BrickColour.LightBlue:
                        GameManager.Instance.LightBlueBricks++;
                        break;
                    case BrickColour.Green:
                        GameManager.Instance.GreenBricks++;
                        break;
                    case BrickColour.Red:
                        GameManager.Instance.RedBricks++;
                        break;
                    case BrickColour.Blue:
                        GameManager.Instance.BlueBricks++;
                        break;
                    case BrickColour.Purple:
                        GameManager.Instance.PurpleBricks++;
                        break;
                    case BrickColour.Yellow:
                        GameManager.Instance.YellowBricks++;
                        break;
                    case BrickColour.Silver:
                        GameManager.Instance.SilverBricks++;
                        break;
                }
            }
        }
    }
}
