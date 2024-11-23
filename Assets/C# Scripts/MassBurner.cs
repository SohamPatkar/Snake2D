using UnityEngine;

public class MassBurner : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SnakeMovement>() != null)
        {
            Debug.Log("Collision");
            SnakeMovement snakeMovement = other.gameObject.GetComponent<SnakeMovement>();
            snakeMovement.RemoveBodyPart();
            Destroy(gameObject, 1f);
        }
    }
}
