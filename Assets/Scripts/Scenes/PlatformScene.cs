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

    void Start() {
        Level level = LevelLoader.LoadOfficialLevel(LevelSystem.Instance.Level);
        foreach (var brick in level.Bricks) {
            GameObject obj;
            // FIXME: this code is just bad
            switch (brick.Colour) {
                case BrickColour.White:
                    obj = Instantiate(BrickWhite, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Orange:
                    obj = Instantiate(BrickOrange, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.LightBlue:
                    obj = Instantiate(BrickLightBlue, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Green:
                    obj = Instantiate(BrickGreen, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Red:
                    obj = Instantiate(BrickRed, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Blue:
                    obj = Instantiate(BrickBlue, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Purple:
                    obj = Instantiate(BrickPurple, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Yellow:
                    obj = Instantiate(BrickYellow, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Silver:
                    obj = Instantiate(BrickSilver, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
                case BrickColour.Gold:
                    obj = Instantiate(BrickGold, new Vector3(brick.Left / 1000.0f, brick.Top / 1000.0f, 0), Quaternion.identity);
                    obj.transform.SetParent(BrickHolder.transform);
                    break;
            }
        }
    }
}
