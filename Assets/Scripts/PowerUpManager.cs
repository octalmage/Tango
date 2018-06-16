using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerups;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(RandomWait());
    }

    IEnumerator RandomWait()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            GameObject powerup = Instantiate(powerups[0], randomPositionOnScreen, powerups[0].transform.rotation);
            powerup.SetActive(true);
        }
    }
}
