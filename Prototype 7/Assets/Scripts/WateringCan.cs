using UnityEngine;
using System.Collections;

public class WateringCan : MonoBehaviour
{
    public Sprite wateringCan1;
    public Sprite wateringCan2;
    public float wateringTime = 0.5f;

    // other
    private SpriteRenderer sp;
    private bool isWatering = false;

    void Start() {
        sp = GetComponent<SpriteRenderer>(); 
        isWatering = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos; 

        if (Input.GetMouseButtonDown(0)) // 0 = left click
        {
            StartCoroutine(Water());
        }
    }

    private IEnumerator Water() {
        // sp.sprite = wateringCan2;
        yield return new WaitForSeconds(wateringTime);
        // sp.sprite = wateringCan1;
    }

    public bool IsWatering() {
        return isWatering;
    }
}
