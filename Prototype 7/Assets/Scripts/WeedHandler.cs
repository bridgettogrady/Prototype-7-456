using UnityEngine;
using System.Collections;

public class WeedHandler : MonoBehaviour
{
    public float maxX = 7.5f;
    public float maxY = 5.5f;
    public GameObject weed;
    public int numRepeatingIntervals = 3;
    public float startingInterval = 3f;
    public float minInterval = 1f;
    private float currInterval;

    void Start()
    {
        Instantiate(weed, PickLocation(), Quaternion.identity);
        currInterval = startingInterval;
        StartCoroutine(Spawn());
    }

    private Vector2 PickLocation() {
        float x = Random.Range(-maxX, maxX);
        float y = Random.Range(-maxY, maxY);
        return new Vector2(x, y);
    }

    private IEnumerator Spawn() {
        while (true) {
            for (int i = 0; i < numRepeatingIntervals; i ++) {
                yield return new WaitForSeconds(currInterval);
                Instantiate(weed, PickLocation(), Quaternion.identity);
            }
            if (currInterval - 0.5f >= minInterval) {
                currInterval -= 0.5f;
            }
        }
    }
}
