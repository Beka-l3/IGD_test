using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement_button : MonoBehaviour{

    public Transform hammerBtn;
    public Transform flyBtn;

    public Button hBtn;
    public Button fBtn;
    private bool hammerIsActive;

    void Start(){
        hammerIsActive = true;
    }

    public void changeActive(bool hammerIsClicked){
        if (hammerIsActive == hammerIsClicked) {
            return;
        }
        else{
            if(hammerIsActive){
                hammerBtn.localScale = new Vector3(0.9f, 0.9f, 1f);
                flyBtn.localScale = new Vector3(1f, 1f, 1f);

                ColorBlock hCB = hBtn.colors;
                hCB.normalColor = new Color(1,1,1,0.5f);
                hBtn.colors = hCB;

                ColorBlock fCB = fBtn.colors;
                fCB.normalColor = new Color(1,1,1,1);
                fBtn.colors = fCB;

                hammerIsActive = false;
            }
            else{
                flyBtn.localScale = new Vector3(0.9f, 0.9f, 1f);
                hammerBtn.localScale = new Vector3(1f, 1f, 1f);

                ColorBlock hCB = hBtn.colors;
                hCB.normalColor = new Color(1,1,1,1);
                hBtn.colors = hCB;

                ColorBlock fCB = fBtn.colors;
                fCB.normalColor = new Color(1,1,1,0.5f);
                fBtn.colors = fCB;

                hammerIsActive = true;
            }
        }
    }
}
