using UnityEngine;
using System.Collections;

public class RainSystem : MonoBehaviour
{
    public AudioSource rainSound;
    public SpriteRenderer sky;
    public Color sunny = new Color(162f/255f, 227f/255f, 252f/255f);
    public Color rainy = new Color(152f/255f, 166f/255f, 172f/255f);

    private bool isRaining = false;

    void Start()
    {
        sky.color = sunny;
        StartCoroutine(RainCycle());
    }

    private IEnumerator RainCycle()
    {
        while(true)
        {
            float nextRain = Random.Range(3f, 5f); //rain evey 3-3 seconds
            yield return new WaitForSeconds(nextRain);

            if (!isRaining)
            {
                isRaining = true;
                Rain();
                yield return new WaitForSeconds(rainSound.clip.length);
                StopRain();
            }
        }
    }

    private void Rain()
    {
        sky.color = rainy;
        rainSound.Play();

        FlowerGrow[] flowers = FindObjectsOfType<FlowerGrow>();
        WeedGrow[] weeds = FindObjectsOfType<WeedGrow>();

        foreach (FlowerGrow flower in flowers)
        {
            flower.StartRain();
        }

        foreach (WeedGrow weed in weeds)
        {
            weed.StartRain();
        }
    }

    private void StopRain()
    {
        isRaining = false;
        sky.color = sunny;

        FlowerGrow[] flowers = FindObjectsOfType<FlowerGrow>();
        WeedGrow[] weeds = FindObjectsOfType<WeedGrow>();

        foreach (FlowerGrow flower in flowers)
        {
            flower.StopRain();
        }

        foreach (WeedGrow weed in weeds)
        {
            weed.StopRain();
        }
    }
}
