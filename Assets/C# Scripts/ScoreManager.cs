using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + 0;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void ScoreDisplay(int playerScore)
    {
        scoreText.text = "Score: " + playerScore;
    }

}
