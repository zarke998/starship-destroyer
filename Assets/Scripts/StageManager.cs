using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] formationPrefabs;
    private GameObject currentFormation;
    public float formationSpawnDelay = 0.5f;

    public GameObject[] bosses;

    void Start()
    {
        currentFormation = GameObject.Instantiate(formationPrefabs[0], transform.position, Quaternion.identity, transform);
        currentFormation.GetComponent<Formation>().FormationDead += FormationDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FormationDied(object sender, EventArgs e){
        currentFormation.GetComponent<Formation>().FormationDead -= FormationDied;
        Destroy(currentFormation);

        Invoke("CreateFormation", formationSpawnDelay);
    }

    void CreateFormation(){
        var rand = Mathf.RoundToInt(UnityEngine.Random.Range(0, formationPrefabs.Length));

        currentFormation = GameObject.Instantiate(formationPrefabs[rand], transform.position, Quaternion.identity, transform);
        currentFormation.GetComponent<Formation>().FormationDead += FormationDied;
    }
}
