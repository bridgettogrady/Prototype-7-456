using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Weed : MonoBehaviour
{
    // weeds
    public Sprite weed1;
    public Sprite weed2;
    public Sprite weed3;
    public float growthInterval = 3f;

    // other
    private List<Sprite> weeds;
    private int currSprite = 0; // because it starts on seeds
    private SpriteRenderer sp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = weed1;

        weeds = new List<Sprite> {weed1, weed2, weed3};

        StartCoroutine(GrowWeed());
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
                Destroy(gameObject);
            }
        }
    }

    private void ChangeSprite() {
        sp.sprite = weeds[currSprite];
    }

    private IEnumerator GrowWeed() {
        yield return new WaitForSeconds(growthInterval);
        currSprite++;
        ChangeSprite();
        yield return new WaitForSeconds(growthInterval);
        currSprite++;
        ChangeSprite();
    }
}
