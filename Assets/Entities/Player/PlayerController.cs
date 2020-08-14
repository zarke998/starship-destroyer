using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 5.0f;
    public float projectileFireRate = 0.2f;
    public AudioClip fireSound;

    public float health = 250.0f;
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
            health -= missile.GetDamage();
            missile.Hit();

            if(health <= 0){
                Destroy(gameObject);
            }
        }
    }

    void Fire(){
        var beamStartPosition = new Vector3(transform.position.x, transform.position.y + transform.localScale.y * 0.5f + 0.5f , 0);
        var beam = Instantiate(projectile, beamStartPosition, Quaternion.identity);

        beam.GetComponent<Rigidbody2D>().velocity = Vector3.up * projectileSpeed;

        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}
