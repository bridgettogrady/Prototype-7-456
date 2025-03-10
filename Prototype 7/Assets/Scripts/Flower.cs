using UnityEngine;
using System.Collections.Generic;

public class Flower : MonoBehaviour
{
    // flowers
    public Sprite seeds;
    public Sprite flower1;
    public Sprite flower2;
    public Sprite flower3;
    public WateringCan wateringCan;

    // other
    private List<Sprite> flowers;
    private int currSprite = -1; // because it starts on seeds
    private SpriteRenderer sp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = seeds;

        flowers = new List<Sprite> {flower1, flower2, flower3};
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = left click
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (wateringCan.IsWatering()) {
                    Debug.Log("true");
                }
                else {
                    Debug.Log("false");
                }
                if (wateringCan != null) {
                    if (currSprite != 2) {
                        currSprite++;
                        sp.sprite = flowers[currSprite];
                    }  
                }

            }
        }
    }
}
