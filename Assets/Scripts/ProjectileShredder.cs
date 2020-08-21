using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShredder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<Projectile>() != null){
            Destroy(collider.gameObject);
        }
    }
}
