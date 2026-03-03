using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class SelectedPlayer : MonoBehaviour
{

    [SerializeField] private Sprite[] _playerSprites;
    [SerializeField] private RuntimeAnimatorController[] _animatorControllers;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private int _selectedPlayer = 0;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        UpdateCharacter();
    }

    public void NextCharacter()
    {
        if (_selectedPlayer < _playerSprites.Length - 1)
        {
            _selectedPlayer++;
            UpdateCharacter();
        }
        else
        {
            _selectedPlayer = 0;
            UpdateCharacter();
        }
    }

    public void PreviousCharacter()
    {
        if (_selectedPlayer > 0)
        {
            _selectedPlayer--;
            UpdateCharacter();
        }
        else
        {
            _selectedPlayer = _playerSprites.Length - 1;
            UpdateCharacter();
        }
    }

    void UpdateCharacter()
    {
        if (_animator != null && _selectedPlayer <= _animatorControllers.Length - 1)
        {
            _animator.enabled = true;
            _animator.runtimeAnimatorController = _animatorControllers[_selectedPlayer];
            Settings.Instance.SetPlayerAnimator(_animatorControllers[_selectedPlayer]);
        }
        else if (_spriteRenderer != null && _selectedPlayer <= _playerSprites.Length - 1)
        {
            _animator.enabled = false;
            _spriteRenderer.sprite = _playerSprites[_selectedPlayer];
            Settings.Instance.SetPlayerAnimator(null);
        }


        Settings.Instance.SetPlayerSprite(_playerSprites[_selectedPlayer]);
    }

}
