using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1.0f;
    public float shotsPerSecond = 0.5f;
    private float projectileOffsetY = -1f;

    public float health = 150f;

    private ScoreKeeper scoreKeeper;
    public int scoreValue = 150;

    void Start(){
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update(){
        float probability = Time.deltaTime * shotsPerSecond;
        if(Random.value < probability){
            Fire();
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        var missile = collider.gameObject.GetComponent<Projectile>() as Projectile;
        if(missile){
            health -= missile.GetDamage();
            missile.Hit();

            if(health <= 0){
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
            }
        }
    }

    void Fire(){
        var missile = Instantiate(projectilePrefab, transform.position + new Vector3(0, projectileOffsetY, 0), Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = Vector3.down * projectileSpeed;
    }
}
