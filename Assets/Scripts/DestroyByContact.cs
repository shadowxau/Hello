using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' object");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Object.Instantiate(explosion, transform.position, Quaternion.identity);
            if (other.tag == "Player")
            {
                Object.Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                gameController.GameOver();
            }
            else // only add score if it wasn't by player collision
            {
                gameController.AddScore(10);
            }

            Destroy(gameObject);
        }
    }
}
