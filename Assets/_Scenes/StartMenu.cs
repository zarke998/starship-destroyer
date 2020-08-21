using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    void Awake(){
        Initialize();
    }  

    void Initialize(){
        PlayerStatistics.Instance.Load();
    }

    public void Instructions_Click(){
        GameObject.Find("Start Menu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("InstructionsPanel").GetComponent<Canvas>().enabled = true;
    }

    public void InstructionsBack_Click(){
        GameObject.Find("Start Menu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("InstructionsPanel").GetComponent<Canvas>().enabled = false;
    }
}
