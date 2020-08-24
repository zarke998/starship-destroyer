using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool gamePaused;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!gamePaused){
                PauseGame();
            }
            else{
                ResumeGame();
            }
        }
    }

    public void PauseGame(){
        Time.timeScale = 0.0f;
        
        GetComponent<Canvas>().enabled = true;

        gamePaused = true;
    }

    public void ResumeGame(){
        Time.timeScale = 1.0f;

        GetComponent<Canvas>().enabled = false;

        gamePaused = false;
    }

    public void MainMenuBtn_Click(){
        ResumeGame();
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Start Menu");
    }
}
