using UnityEngine;

public class MassGainer : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SnakeMovement>() != null)
        {
            Debug.Log("Collision");
            SnakeMovement snakeMovement = other.gameObject.GetComponent<SnakeMovement>();
            snakeMovement.AddBodyPart();
            Destroy(gameObject, 1f);
        }
    }
}
