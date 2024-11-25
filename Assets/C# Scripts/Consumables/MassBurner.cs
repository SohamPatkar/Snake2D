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
            SoundManager.Instance.PlaySfx(SoundType.Eaten);
            SnakeMovement snakeMovement = other.gameObject.GetComponent<SnakeMovement>();
            snakeMovement.RemoveBodyPart();
            snakeMovement.SubtractScore();
            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponent<PlayerTwo>() != null)
        {
            Debug.Log("Collision");
            SoundManager.Instance.PlaySfx(SoundType.Eaten);
            PlayerTwo playerTwo = other.gameObject.GetComponent<PlayerTwo>();
            playerTwo.RemoveBodyPart();
            playerTwo.SubtractScore();
            Destroy(gameObject);
        }
    }
}
