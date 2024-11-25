using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class GameOver : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playAgain, goHome, backButton;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(GoBack);
        playAgain.onClick.AddListener(OnPlayAgain);
        goHome.onClick.AddListener(GoHome);
    }

    void GoBack()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    void OnPlayAgain()
    {
        Time.timeScale = 1;
        SoundManager.Instance.PlaySfx(SoundType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoHome()
    {
        Time.timeScale = 1;
        SoundManager.Instance.PlaySfx(SoundType.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
