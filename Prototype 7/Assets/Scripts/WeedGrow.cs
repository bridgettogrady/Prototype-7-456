using UnityEngine;

public class WeedGrow : MonoBehaviour
{
    public Sprite[] growthStages;
    private SpriteRenderer spriteRenderer;
    private int currentStage = 0;
    private float growthTimer = 0f;
    public float timeBetweenStages = 1f; //weed regular grow speed
    public GameObject seedOverlay;
    public AudioClip pluckSound;
    private AudioSource audioSource;
    private bool killed = false;
    private WeedSpawner weedSpawner;
    private bool seeded = false;
    private bool isRaining = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = growthStages[currentStage];

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake= false;

        weedSpawner = FindObjectOfType<WeedSpawner>();

        if (seedOverlay != null)
        {
            seedOverlay.SetActive(false);
        }
    }
        

    void Update()
    {
        if (killed) return;
        GrowthCycle();
    }

    void GrowthCycle()
    {
        if (seeded) return;

        growthTimer += Time.deltaTime * (isRaining ? 4f:1f); // grows four times faster when rain

        if (growthTimer >= timeBetweenStages && currentStage < 2)
        {
            currentStage++;
            spriteRenderer.sprite = growthStages[currentStage];
            growthTimer = 0f;
        }
        else if (currentStage >= 2)
        {
            seedOverlay.SetActive(true);
            weedSpawner.UpdateSeedCount(true);
            seeded = true;
        }
    }

    void OnMouseDown()
    {
        killed = true;
        weedSpawner.WeedRemoved();
        GetComponent<Collider2D>().enabled = false;
        spriteRenderer.enabled = false;
        if (seedOverlay != null && seedOverlay.activeSelf)
        {
            Destroy(seedOverlay);
            weedSpawner.UpdateSeedCount(false);
        }

        if (pluckSound != null)
        {
            audioSource.PlayOneShot(pluckSound);
        }

        Destroy(gameObject, pluckSound.length);
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
