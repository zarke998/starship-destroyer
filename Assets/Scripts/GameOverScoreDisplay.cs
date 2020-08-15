using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreDisplay : MonoBehaviour
{
    void Start()
    {
        var label = GetComponent<Text>();
        label.text = $"Your score: {ScoreKeeper.score}";
    }
}
