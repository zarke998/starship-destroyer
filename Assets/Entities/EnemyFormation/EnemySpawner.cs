﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float width = 15.0f;
    public float height = 10.0f;

    private float xmin;
    private float xmax;

    public float speed = 15.0f;
    private bool movingRight;

    void Start()
    {
        var distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        var leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera));
        var rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera));

        xmin = leftBoundary.x;
        xmax = rightBoundary.x;

        foreach(Transform child in transform){
            var enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
    }

    void Update()
    {
        if(movingRight){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else{
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        var leftEdge = transform.position.x - (width * 0.5f);
        var rightEdge = transform.position.x + (width * 0.5f);

        if(leftEdge <= xmin) {
            movingRight = true;
        }
        else if(rightEdge >= xmax){
            movingRight = false;
        }
    }
}