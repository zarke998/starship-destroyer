using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public GameObject iconPrefab;
    private float iconWidth;
    private float iconHeight;
    public float marginLeft = 1.0f;

    private float canvasScaleX;
    private float canvasScaleY;

    // Start is called before the first frame update
    void Awake()
    {
        iconWidth = Mathf.Round(GetComponent<RectTransform>().rect.width);
        iconHeight = Mathf.Round(GetComponent<RectTransform>().rect.height);

        Debug.Log($"Width {iconWidth}");
        Debug.Log($"Height {iconHeight}");
    }

    void Start(){
        canvasScaleX = GameObject.Find("GUI").GetComponent<RectTransform>().localScale.x;
        canvasScaleY = GameObject.Find("GUI").GetComponent<RectTransform>().localScale.y;

        var startingHealth = GameObject.Find("Player").GetComponent<PlayerController>().healthLives;
        UpdateHealth(startingHealth);
    }

    public void UpdateHealth(int healthLives){
        ClearGUI();

        Vector3 drawPos = transform.position;
        Debug.Log($"Draw pos: {drawPos}");

        for(int i = 0; i < healthLives; i++){
            var heart = GameObject.Instantiate(iconPrefab, drawPos, Quaternion.identity, transform);
            heart.GetComponent<RectTransform>().sizeDelta = new Vector2(iconWidth, iconHeight);

            drawPos = drawPos + new Vector3(iconWidth * canvasScaleX + marginLeft, 0, 0);
            Debug.Log($"Draw pos: {drawPos}");
        }
    }

    void ClearGUI(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
    }
}
