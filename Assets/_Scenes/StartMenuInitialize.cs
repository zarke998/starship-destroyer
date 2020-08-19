using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuInitialize : MonoBehaviour
{
    void Awake(){
        PlayerStatistics.Instance.Load();
    }    
}
