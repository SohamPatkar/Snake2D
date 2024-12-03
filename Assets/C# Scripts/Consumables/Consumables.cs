using UnityEngine;
using UnityEngine.UI;

public enum FoodType
{
    MassGainer,
    MassBurner
}

public class Food : MonoBehaviour
{
    public FoodType typeOfFood;
    public void MassGainerEaten(GameObject player)
    {
        PlaySound();
        if (player.gameObject.GetComponent<PlayerOne>() != null)
        {
            PlayerOne playerOneScript = player.gameObject.GetComponent<PlayerOne>();
            SnakeMovement.Instance.AddScore(player);
            SnakeMovement.Instance.AddBodyPart(playerOneScript.snakeBodyParts, playerOneScript.playerBodyPart, player.gameObject.transform);
            Destroy(gameObject);
        }
        else if (player.gameObject.GetComponent<PlayerTwo>() != null)
        {
            PlayerTwo playerTwoScript = player.gameObject.GetComponent<PlayerTwo>();
            SnakeMovement.Instance.AddScore(player);
            SnakeMovement.Instance.AddBodyPart(playerTwoScript.snakeBodyParts, playerTwoScript.playerBodyPart, player.gameObject.transform);
            Destroy(gameObject);
        }
    }

    public void MassBurnerEaten(GameObject player)
    {
        PlaySound();
        if (player.gameObject.GetComponent<PlayerOne>() != null)
        {
            PlayerOne playerOneScript = player.gameObject.GetComponent<PlayerOne>();
            SnakeMovement.Instance.RemoveBodyPart(playerOneScript.snakeBodyParts);
            Destroy(gameObject);
        }
        else if (player.gameObject.GetComponent<PlayerTwo>() != null)
        {
            PlayerTwo playerTwoScript = player.gameObject.GetComponent<PlayerTwo>();
            SnakeMovement.Instance.RemoveBodyPart(playerTwoScript.snakeBodyParts);
            Destroy(gameObject);
        }
    }

    private void PlaySound()
    {
        SoundManager.Instance.PlaySfx(SoundType.Eaten);
    }
}
