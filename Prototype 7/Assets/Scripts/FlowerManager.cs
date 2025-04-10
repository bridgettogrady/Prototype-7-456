using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerManager : MonoBehaviour
{
    private int numDead = 0;
    public GameObject spawner;

    public void FlowerDead() {
        numDead++;
        if (numDead == 5) {
            Lose();
        }
    }

    private void Lose() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            spawner.SetActive(true);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
