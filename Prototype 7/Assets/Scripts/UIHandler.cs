using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Image winImage;
    public GameObject weedSpawner;
    private bool won = false;
    private AudioSource audioSource;
    public AudioClip winSound;

    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake= false;
    }

    public void Win() {
        if (won) {
            return;
        }
        audioSource.PlayOneShot(winSound, 0.5f);
        winImage.gameObject.SetActive(true);
        winImage.enabled = true;
    }
}
