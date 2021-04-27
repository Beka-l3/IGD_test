using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class resource_prefab_movement : MonoBehaviour{
    TMP_Text prefab;
    Transform prefabTransform;
    Transform parent;
    private Transform parentText;
    private float timer;
    private int prefabNum;
    private int parentNum;

    void Start(){
        prefab = gameObject.GetComponent<TMP_Text>();
        prefabTransform = gameObject.GetComponent<Transform>();
        parent = prefabTransform.parent.GetComponent<Transform>();

        if(parent.tag == "xpIcon") parentText = parent.GetChild(1);
        else parentText = parent.GetChild(0);

        prefabNum = int.Parse(prefabTransform.GetComponent<TMP_Text>().text.Substring(1));
        timer = 0f;
    }

    void Update(){
        prefabTransform.position = new Vector3(parent.position.x, Mathf.Lerp(prefabTransform.position.y, parent.position.y, Time.deltaTime*3), parent.position.z);

        timer += Time.deltaTime;
        if (timer >= 1f){
            if (prefabTransform.GetComponent<TMP_Text>().text[0] == '+'){
                if(parent.tag == "xpIcon"){
                    parentNum = int.Parse(parentText.GetComponent<Text>().text.Substring(4));
                    Transform parentColor = parent.GetChild(0);
                    // Debug.Log(parentColor.localScale);

                    parentNum *= 100;
                    parentNum += (int)(parentColor.localScale.x * 100);
                    parentNum += prefabNum;

                    if (parentNum > 99999) parentNum = 99999;

                    Vector3 newScale = new Vector3( (parentNum%100)/100f, 1f, 1f);
                    parentColor.localScale = newScale;

                    parentText.GetComponent<Text>().text = "LVL " + (parentNum/100).ToString();
                }
                else{
                    parentNum = int.Parse(parentText.GetComponent<Text>().text);
                    parentNum += prefabNum;

                    if(parentNum > 999999) parentNum = 999999;

                    parentText.GetComponent<Text>().text = parentNum.ToString();
                }                
            }
            else{
                if(parent.tag == "xpIcon"){
                    parentNum = int.Parse(parentText.GetComponent<Text>().text.Substring(4));
                    Transform parentColor = parent.GetChild(0);

                    parentNum *= 100;
                    parentNum += (int)(parentColor.localScale.x * 100);
                    parentNum -= prefabNum;

                    if (parentNum < 100){
                        parentNum = 100;
                    }
                    Vector3 newScale = new Vector3( (parentNum%100)/100f, 1f, 1f);
                    parentColor.localScale = newScale;

                    parentText.GetComponent<Text>().text = "LVL " + (parentNum/100).ToString();

                }
                else{
                    parentNum = int.Parse(parentText.GetComponent<Text>().text);

                    parentNum -= prefabNum;
                    if(parentNum < 0) parentNum = 0;

                    parentText.GetComponent<Text>().text = parentNum.ToString();
                }                
            }

            Destroy(gameObject);
        }

    }
}
