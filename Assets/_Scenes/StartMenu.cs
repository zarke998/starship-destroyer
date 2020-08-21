using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    bool musicEnabled;

    void Awake(){
        Initialize();
    }  

    void Start(){
        musicEnabled = Settings.Instance.MusicEnabled;
        MusicPlayerToggle(musicEnabled);
    }

    void Initialize(){
        PlayerStatistics.Instance.Load();
        Settings.Instance.Load();
    }

    public void Music_Click(){
        musicEnabled = !musicEnabled;
        MusicPlayerToggle(musicEnabled);

        Settings.Instance.MusicEnabled = musicEnabled;
        Settings.Instance.Save();
    }

    void MusicPlayerToggle(bool active){
        MusicPlayer.instance.gameObject.SetActive(active);

        if(active){
            GameObject.Find("Music").GetComponent<Text>().text = "Music: ON";
        }
        else{
            GameObject.Find("Music").GetComponent<Text>().text = "Music: OFF";
        }
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
