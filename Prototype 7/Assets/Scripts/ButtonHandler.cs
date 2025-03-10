using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject wateringCan;
    private GameObject currCan;
    public void WateringCanButton() {
        if (currCan == null) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currCan = Instantiate(wateringCan, mousePos, Quaternion.identity);
        }
        else {
            Destroy(currCan);
        }
    }
}
