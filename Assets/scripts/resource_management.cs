using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

public class resource_management : MonoBehaviour{

    public GameObject blockInfo;
    public GameObject coinInfo;
    public GameObject diamondInfo;
    public GameObject xpInfo;

    public GameObject blockBtn;
    public GameObject coinBtn;
    public GameObject diamondBtn;
    public GameObject xpBtn;

    public TMP_Text resourcePrefab;

    public GameObject joystickBorder;
    private Transform joystickCenter;


    void Start(){
        joystickCenter = joystickBorder.GetComponentsInChildren<Transform>()[1];
    }

    private string getRequest(string resourceName, string resourceAmount){
        string amount = "+0";

        string hostname = "http://127.0.0.1:5000";

        if(resourceAmount == "") return amount;
        else{
            var web = new WebClient();
            string url = $"{hostname}/{resourceName}?amount={resourceAmount}";
            amount = web.DownloadString(url);

        }
        return amount;
    }

    public void addResource(string resourceName){
        TMP_Text resourceTxt;
        Text txt;
        string serverResponse;
        // string resourceName;

        if(resourceName == "block"){
            Transform[] allChildren = blockBtn.GetComponentsInChildren<Transform>();
            txt = allChildren[allChildren.Length-1].GetComponent<Text>();        
        }
        else if(resourceName == "coin"){
            Transform[] allChildren = coinBtn.GetComponentsInChildren<Transform>();
            txt = allChildren[allChildren.Length-1].GetComponent<Text>();
        }
        else if(resourceName == "diamond"){
            Transform[] allChildren = diamondBtn.GetComponentsInChildren<Transform>();
            txt = allChildren[allChildren.Length-1].GetComponent<Text>();
        }
        else {
            Transform[] allChildren = xpBtn.GetComponentsInChildren<Transform>();
            txt = allChildren[allChildren.Length-1].GetComponent<Text>();
        }

        for(int i = 0; i<txt.text.Length; i++){
            if(txt.text[i] == '-') continue;
            if(txt.text[i] == '+') continue;
            if(!char.IsDigit(txt.text[i])) return;
        }

        serverResponse = getRequest(resourceName, txt.text);

        resourceTxt = Instantiate(resourcePrefab, new Vector3(0, -30f, 0), Quaternion.identity) as TMP_Text;
        resourceTxt.transform.SetParent(GameObject.FindGameObjectWithTag(resourceName+"Icon").transform, false);         

        if(serverResponse != ""){
            resourceTxt.text = serverResponse;
            if(serverResponse[0] != '-'){
                if(serverResponse[0] != '+') resourceTxt.text = "+" + serverResponse;
                resourceTxt.color = new Color32(30, 180, 30, 255);
            }
            else resourceTxt.color = new Color32(180, 30, 30, 255);
        }
        else resourceTxt.text = "+0";
        resourceTxt.fontSize = 16;
   
    }

}
