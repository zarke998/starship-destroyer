using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    void Start()
    {
        Text label = GetComponent<Text>();
        label.text = PlayerStatistics.Instance.HighScore.ToString();
    }
}
