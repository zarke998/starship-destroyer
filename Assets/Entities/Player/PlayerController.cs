using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 5.0f;
    public float projectileFireRate = 0.2f;
    public AudioClip fireSound;

    public int healthLives = 3;
    private PlayerHealthDisplay healthDisplay;

    public float speed = 15.0f;
    public float padding = 1.0f;


    float xmin;
    float xmax;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;

        var leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;

        Debug.Log(leftmost.ToString());
        Debug.Log(rightmost.ToString());


        healthDisplay = GameObject.Find("Player Health Display").GetComponent<PlayerHealthDisplay>();
        healthDisplay.UpdateHealth(healthLives);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            InvokeRepeating("Fire", 0.000001f, projectileFireRate);
        }
        else if(Input.GetKeyUp(KeyCode.Space)){
            CancelInvoke("Fire");
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider){
        var missile = collider.gameObject.GetComponent<Projectile>() as Projectile;
        if(missile){
            healthLives--;
            healthDisplay.UpdateHealth(healthLives);

            missile.Hit();

            if(healthLives <= 0){
                Die();
            }
        }
    }

    void Fire(){
        var beamStartPosition = new Vector3(transform.position.x, transform.position.y + transform.localScale.y * 0.5f + 0.5f , 0);
        var beam = Instantiate(projectile, beamStartPosition, Quaternion.identity);

        beam.GetComponent<Rigidbody2D>().velocity = Vector3.up * projectileSpeed;

        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    void Die(){
        var levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.LoadLevel("Win Screen");
        Destroy(gameObject);
    }
}
