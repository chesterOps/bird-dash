using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _highscoreText;

    void Start()
    {
        _highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
    public void LoadGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
