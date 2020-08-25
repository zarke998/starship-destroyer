using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject[] formationPrefabs;
    private GameObject currentFormation;
    public float formationSpawnDelay = 0.5f;
    
    private int stage = 1;
    private float stageFireSpeedIncrement = 0.1f;
    private int formationsPerStage = 3;
    private int formationDeaths;

    public GameObject[] bosses;

    void Start()
    {
        currentFormation = GameObject.Instantiate(formationPrefabs[0], transform.position, Quaternion.identity, transform);
        currentFormation.GetComponent<Formation>().FormationDead += FormationDied;
    }

    void FormationDied(object sender, EventArgs e){
        currentFormation.GetComponent<Formation>().FormationDead -= FormationDied;
        Destroy(currentFormation);
        formationDeaths++;

        if(formationDeaths >= formationsPerStage){
            stage++;
            GameObject.Find("Stage").GetComponent<Text>().text = stage.ToString();

            EnemyBehaviour.shotsPerSecond += stageFireSpeedIncrement;
            
            formationDeaths = 0;
        }

        Invoke("CreateFormation", formationSpawnDelay);
    }

    void CreateFormation(){
        var rand = Mathf.RoundToInt(UnityEngine.Random.Range(0, formationPrefabs.Length));

        currentFormation = GameObject.Instantiate(formationPrefabs[rand], transform.position, Quaternion.identity, transform);
        currentFormation.GetComponent<Formation>().FormationDead += FormationDied;
    }
}
