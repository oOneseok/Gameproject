using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Font Bold;
    public int fontSize = 40;

    private void Start()
    {
        Text startButtonText = startButton.GetComponentInChildren<Text>();
        startButtonText.text = "게임 시작";
        startButtonText.font = Bold;
        startButtonText.fontSize = fontSize;

        Text quitButtonText = quitButton.GetComponentInChildren<Text>();
        quitButtonText.text = "게임 종료";
        quitButtonText.font = Bold;
        quitButtonText.fontSize = fontSize;


        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);

        void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        void QuitGame()
        {
            Application.Quit();
        }
    }
}