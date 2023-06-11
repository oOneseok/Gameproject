using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;
    public Font Bold;
    public int fontSize = 40;

    private void Start()
    {
        Text restartButtonText = restartButton.GetComponentInChildren<Text>();
        restartButtonText.text = "다시 시작";
        restartButtonText.font = Bold;
        restartButtonText.fontSize = fontSize;

        Text quitButtonText = quitButton.GetComponentInChildren<Text>();
        quitButtonText.text = "게임 종료";
        quitButtonText.font = Bold;
        quitButtonText.fontSize = fontSize;


        restartButton.onClick.AddListener(reStartGame);
        quitButton.onClick.AddListener(QuitGame);

        void reStartGame()
        {
            SceneManager.LoadScene(1);
        }

        void QuitGame()
        {
            Application.Quit();
        }
    }
}