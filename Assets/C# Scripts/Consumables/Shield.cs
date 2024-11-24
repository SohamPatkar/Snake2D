using UnityEngine;

public class Shield : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SnakeMovement>() != null)
        {
            SnakeMovement snakeMovement = other.gameObject.GetComponent<SnakeMovement>();
            snakeMovement.Shield();
            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponent<PlayerTwo>() != null)
        {
            PlayerTwo playerTwo = other.gameObject.GetComponent<PlayerTwo>();
            playerTwo.Shield();
            Destroy(gameObject);
        }
    }
}
