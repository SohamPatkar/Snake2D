using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton, coopButton;
    private void Start()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
        coopButton.onClick.AddListener(CoopButtonClicked);
    }

    void PlayButtonClicked()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    void CoopButtonClicked()
    {
        SceneManager.LoadScene("Coop");
    }
}
