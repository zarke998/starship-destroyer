using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
