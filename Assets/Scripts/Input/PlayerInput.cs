using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Player Input")]
public class PlayerInput : ScriptableObject, InputActions.IGamePlayActions
{
    public event UnityAction<Vector2> onMove = delegate {};
    public event UnityAction onStopMove = delegate {};

    InputActions inputActions;
    private void OnEnable() 
    {
        inputActions = new InputActions();
        inputActions.GamePlay.SetCallbacks(this);
    }

    public void EnableGameplayInput()
    {
        inputActions.GamePlay.Enable();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable() {
        DisableAllInput();
    }

    public void DisableAllInput()
    {
        inputActions.GamePlay.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            onMove.Invoke(context.ReadValue<Vector2>());
        }
        if(context.phase == InputActionPhase.Canceled)
        {
            onStopMove.Invoke();
        }
    }

}
