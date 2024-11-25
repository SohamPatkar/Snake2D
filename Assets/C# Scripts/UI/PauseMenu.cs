using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseMenu : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button pauseButton;

    [Header("Pause Screen")]
    [SerializeField] private GameObject pauseScreen;
    private void Awake()
    {
        pauseScreen.SetActive(false);
    }

    private void Start()
    {
        pauseButton = gameObject.GetComponent<Button>();
        pauseButton.onClick.AddListener(PauseGame);
    }

    void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
