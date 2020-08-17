using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    public GameObject iconPrefab;
    private float iconWidth;
    private float iconHeight;
    public float marginLeft = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        iconWidth = Mathf.Round(GetComponent<RectTransform>().rect.width);
        iconHeight = Mathf.Round(GetComponent<RectTransform>().rect.height);
    }

    public void UpdateHealth(int healthLives){
        ClearGUI();

        Vector3 drawPos = transform.position;

        for(int i = 0; i < healthLives; i++){
            var heart = GameObject.Instantiate(iconPrefab, drawPos, Quaternion.identity, transform);
            heart.GetComponent<RectTransform>().sizeDelta = new Vector2(iconWidth, iconHeight);

            drawPos = drawPos + new Vector3(iconWidth + marginLeft, 0, 0);
        }
    }

    void ClearGUI(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
    }
}
