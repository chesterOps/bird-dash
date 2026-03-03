using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputController : MonoBehaviour
{
    public event Action OnJumpButtonPressed;
    private void OnJump(InputValue input)
    {
        if (input.isPressed)
        {
            OnJumpButtonPressed?.Invoke();
        }
    }
}
