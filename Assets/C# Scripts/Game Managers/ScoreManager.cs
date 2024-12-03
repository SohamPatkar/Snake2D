using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText, scoreTwo, playerWon;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameOverScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Player Score: " + 0;
    }

    public void PlayerWon(PlayerType playerType)
    {
        playerWon.text = playerType.ToString() + " Won";
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
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
