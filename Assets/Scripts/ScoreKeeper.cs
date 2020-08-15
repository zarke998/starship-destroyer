using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int score = 0;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();

        Reset();
        scoreText.text = score.ToString();
    }

    public void Score(int scorePoints){
        score += scorePoints;
        scoreText.text = score.ToString();
    }

    public void Reset(){
        score = 0;
    }
}
