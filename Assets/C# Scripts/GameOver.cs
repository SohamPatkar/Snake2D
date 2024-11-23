using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class GameOver : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playAgain, goHome;
    // Start is called before the first frame update
    void Start()
    {
        playAgain.onClick.AddListener(OnPlayAgain);
        goHome.onClick.AddListener(GoHome);
    }

    void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
