using UnityEngine;

public class FlowerGrow : MonoBehaviour
{
    public Sprite[] growthStages;
    public UIHandler UI;
    public FlowerManager manager;
    public GameObject bud;
    private SpriteRenderer budRenderer;

    private SpriteRenderer spriteRenderer;
    private int currentStage = 0;
    private float growthTimer = 0f;
    public float timeBetweenStages = 40f; //flower regular grow speed
    private int nearByWeed = 0;
    private bool isRaining = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = growthStages[currentStage];
        budRenderer = bud.GetComponent<SpriteRenderer>();
    }   

    void Update()
    {
        GrowthCycle();
    }

    void GrowthCycle()
    {
        growthTimer += Time.deltaTime * (isRaining ? 2f:1f); // grows two times faster when rain

        if (growthTimer >= timeBetweenStages && currentStage < 3)
        {
            currentStage++;
            spriteRenderer.sprite = growthStages[currentStage];
            growthTimer = 0f;
        }
        else if (currentStage >= 3)
        {
            budRenderer.enabled = true;
            UI.Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weed"))
        {
            nearByWeed++;
        }
        if (nearByWeed >= 5)
        {
            manager.FlowerDead();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Weed"))
        {
            nearByWeed--;
        }
    }

     public void StartRain()
    {
        isRaining = true;
    }

    public void StopRain()
    {
        isRaining = false;
    }
}
