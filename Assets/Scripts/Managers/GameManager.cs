using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Input input;

    public Input Input => input;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        input = new Input();
        input.ModelView.Enable();
        input.Keybinds.Enable();
    }

    private void Start()
    {
        input.Keybinds.Escape.performed += (InputAction.CallbackContext context) => Application.Quit();
    }

    private void OnDestroy()
    {
        input.Keybinds.Escape.performed -= (InputAction.CallbackContext context) => Application.Quit();
    }
}
