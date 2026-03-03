using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds = new(0.5f);
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TMP_Text _playerScoreText;
    [SerializeField] private TMP_Text _highscoreText;
    [SerializeField] private GameObject _startGameImage;
    [SerializeField] private AudioClip _checkpointSound;
    [SerializeField] private AudioClip _wallHitSound;
    private AudioSource _gameManagerAudioSource;
    private int highscore;

    private BoxCollider2D _groundCollider;
    private Animator _playerAnimator;
    private Animator _startGameImageAnimator;
    public bool HasGameStarted { get; private set; } = false;
    public int PlayerScore { get; private set; } = 0;
    public bool IsGameOver { get; private set; } = false;


    void Awake()
    {
        Time.timeScale = 0;
        _groundCollider = GameObject.Find("Ground").GetComponent<BoxCollider2D>();
        _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        _startGameImageAnimator = _startGameImage.GetComponent<Animator>();
        _gameManagerAudioSource = GetComponent<AudioSource>();

    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        _highscoreText.text = highscore.ToString();
        if (_gameOverScreen != null)
        {
            _gameOverScreen.SetActive(false);
        }
    }


    void Update()
    {
        if (_playerScoreText != null)
        {
            _playerScoreText.text = PlayerScore.ToString();
        }
    }


    public void StartGame()
    {
        if (_startGameImageAnimator != null)
        {
            _startGameImageAnimator.SetBool("run", true);
        }

        Time.timeScale = 1;
        HasGameStarted = true;
        if (_playerAnimator != null)
        {
            _playerAnimator.enabled = false;
        }

    }

    public void RestartGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        // Play wall hit sound
        if (_gameManagerAudioSource != null && _wallHitSound != null)
        {
            _gameManagerAudioSource.PlayOneShot(_wallHitSound);
        }

        IsGameOver = true;
        // Disable ground box collider so player will fall
        if (_groundCollider != null)
        {
            _groundCollider.enabled = false;
        }
        // Show game over screen
        if (_gameOverScreen != null)
        {
            StartCoroutine(DelayGameOver());
        }

    }

    IEnumerator DelayGameOver()
    {
        yield return _waitForSeconds;
        _gameOverScreen.SetActive(true);
    }


    public void IncreasePlayerScore()
    {
        if (IsGameOver) return;



        // Play checkpoint sound
        if (_gameManagerAudioSource != null && _checkpointSound != null)
        {
            _gameManagerAudioSource.PlayOneShot(_checkpointSound);
        }
        PlayerScore++;

        // Update highscore
        if (PlayerScore > highscore)
        {
            PlayerPrefs.SetInt("Highscore", PlayerScore);
            PlayerPrefs.Save();
            highscore = PlayerScore;
            _highscoreText.text = highscore.ToString();
        }
    }
}
