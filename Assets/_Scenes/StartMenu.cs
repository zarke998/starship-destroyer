using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    private GameObject startMenuPanel;
    private GameObject instructionsPanel;

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

        startMenuPanel = GameObject.Find("Start Menu");
        instructionsPanel = GameObject.Find("InstructionsPanel");
        instructionsPanel.SetActive(false);
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
        instructionsPanel.SetActive(true);
        startMenuPanel.SetActive(false);
    }

    public void InstructionsBack_Click(){
        instructionsPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }
}
