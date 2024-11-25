using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton, coopButton, quitButton;
    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        playButton.onClick.AddListener(PlayButtonClicked);
        coopButton.onClick.AddListener(CoopButtonClicked);
    }

    void QuitGame()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
        Application.Quit();
#elif (UNITY_WEBGL)
        Application.OpenURL("about:blank");
#endif
    }

    void PlayButtonClicked()
    {
        SoundManager.Instance.PlaySfx(SoundType.ButtonClick);
        SceneManager.LoadScene("SinglePlayer");
    }

    void CoopButtonClicked()
    {
        SoundManager.Instance.PlaySfx(SoundType.ButtonClick);
        SceneManager.LoadScene("Coop");
    }
}
