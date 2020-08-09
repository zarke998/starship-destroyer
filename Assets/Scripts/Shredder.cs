using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        Destroy(collider.gameObject);
    }

    void Update(){
        float probability = Time.deltaTime * 0.5f;
        float random = Random.value;

        
    }
}
