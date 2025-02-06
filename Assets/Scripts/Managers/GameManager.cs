using UnityEngine;

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
    }
}
