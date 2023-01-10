using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    public static Dialog Ins;
    public TextMeshProUGUI notifiTxt;
    public GameObject dialogPanel;
    void Awake()
    {
        makeSingleton();
    }
    public void setNotiFiText(string content){
        notifiTxt.text = content;
    }
    public void showDialogState(bool state){
        dialogPanel.SetActive(state);
    }
    public void makeSingleton(){
        if(Ins == null){
            Ins = this;
        }else{
            Destroy(gameObject);
        }
    }
}
