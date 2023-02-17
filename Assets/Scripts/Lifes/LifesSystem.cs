using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifesSystem : MonoBehaviour
{
    public static LifesSystem instance;
    public TextMeshProUGUI lifesText;
    int lifes = 3;

    void refreshLifesText(){
        lifesText.text = "Lifes: " + lifes.ToString();
    }

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        refreshLifesText();
    }

    public void addLife(){
        lifes+=1;
    }

    public void removeLife(){
        lifes -= 1;
    }

}
