using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{
    public float width = 15.0f;
    public float height = 10.0f;

    private float xmin;
    private float xmax;

    public float speed = 15.0f;
    private bool movingRight;

    public event EventHandler FormationDead;

    void Start()
    {
        var distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        var leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera));
        var rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera));

        xmin = leftBoundary.x;
        xmax = rightBoundary.x;
        
        // StartCoroutine(SpawnUntilFull());
        SpawnUntilFull();
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

        if(AllEnemiesDead()){
            OnFormationDead();
        }
    }

    void SpawnUntilFull(){
        foreach(Transform position in transform){
            var positionScript = position.gameObject.GetComponent<Position>();
            positionScript.SpawnEnemy();
        }
    }

    bool AllEnemiesDead(){
        foreach(Transform position in transform){
            if(position.childCount > 0)
                return false;
        }
        return true;
    }

    void OnFormationDead(){
        var tempHandler = FormationDead;

        tempHandler?.Invoke(this, new EventArgs());
    }
}
