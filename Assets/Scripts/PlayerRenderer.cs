using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        if (_animator != null && Settings.Instance != null)
        {
            RuntimeAnimatorController selectedAnimatorController = Settings.Instance.SelectedAnimatorController;
            _animator.runtimeAnimatorController = selectedAnimatorController;
        }

        if (_spriteRenderer != null && Settings.Instance != null)
        {
            Sprite selectedPlayerSprite = Settings.Instance.SelectedPlayerSprite;
            _spriteRenderer.sprite = selectedPlayerSprite;
        }

    }

}
