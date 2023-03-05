using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers {
  public class ButtonBehaviour : MonoBehaviour {
    public void ButtonOne(Editor editor) {
      editor.CreateLevel(0);
    }

    public void ButtonTwo(Editor editor) {
      editor.CreateLevel(1);
    }

    public void ButtonThree(Editor editor) {
      editor.CreateLevel(2);
    }

    public void ButtonFour(Editor editor) {
      editor.CreateLevel(3);
    }

    public void ButtonFive(Editor editor) {
      editor.CreateLevel(4);
    }

    public void ButtonSix(Editor editor) {
      editor.CreateLevel(5);
    }
  }
}