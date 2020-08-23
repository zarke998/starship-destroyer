using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float gizmoRadius = 0.5f;

    void OnDrawGizmos(){
        Gizmos.DrawSphere(transform.position, gizmoRadius);
    }

    public void SpawnEnemy(){
        if(transform.childCount > 0){
            return;
        }

        GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
    }
}
