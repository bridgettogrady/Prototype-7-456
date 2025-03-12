using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Image winImage;
    public GameObject spawner;
    private bool won = false;
    private AudioSource audioSource;
    public AudioClip winSound;
    public GameObject flower;
    public float yPos;
    public float maxX;

    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake= false;
    }

    public void Win() {
        if (won) {
            return;
        }
        spawner.SetActive(false);
        Time.timeScale = 0;
    }
}
