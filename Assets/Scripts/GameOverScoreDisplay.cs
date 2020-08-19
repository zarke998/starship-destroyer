using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreDisplay : MonoBehaviour
{
    void Start()
    {
        var label = GetComponent<Text>();
        var statistics = PlayerStatistics.Instance;

        if(ScoreKeeper.score > statistics.HighScore){
            label.text = $"New High score: {ScoreKeeper.score}";

            statistics.HighScore = ScoreKeeper.score;
            statistics.Save();
        }
        else{
            label.text = $"Your score: {ScoreKeeper.score}";
        }
    }
}
