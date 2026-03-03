using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    private PlayerInputController _playerInputController;
    private AudioSource _playerAudioSource;
    [SerializeField]
    private AudioClip _jumpSound;
    private GameManager _gameManager;
    private Rigidbody2D _rb;
    [SerializeField] private float _jumpSpeed;
    void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _playerAudioSource = GetComponent<AudioSource>();
        _playerInputController.OnJumpButtonPressed += JumpPressed;
        _rb = GetComponent<Rigidbody2D>();
    }


    public void JumpPressed()
    {
        if (_gameManager != null && !_gameManager.HasGameStarted)
        {
            _gameManager.StartGame();
        }

        if (_gameManager != null && _gameManager.IsGameOver)
        {
            return;
        }
        _rb.linearVelocity = Vector2.up * _jumpSpeed;
        if (_jumpSound != null)
        {
            _playerAudioSource.PlayOneShot(_jumpSound);
        }
    }

}
