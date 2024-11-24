using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText, scoreTwo, playerWon;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Player Score: " + 0;
    }

    public void PlayerWon(GameObject player)
    {
        playerWon.text = player.name + " Won";
        gameOverScreen.SetActive(true);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void ScoreDisplay(int playerScore)
    {
        scoreText.text = "Player Score: " + playerScore;
    }

    public void PlayerTwoScoreDisplay(int playerTwo)
    {
        scoreTwo.text = "Player Two Score: " + playerTwo;
    }

}
