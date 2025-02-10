using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UIButton button;

    [Header("ButtonColor")]
    [SerializeField] private Color normalColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color hoverColor;

    public void Select(UIButton uiButton)
    {
        if(button != null)
            button.ButtonImage.color = normalColor;

        button = uiButton;
        button.ButtonImage.color = selectedColor;
    }

    public void Hover(UIButton uiButton)
    {
        if(uiButton == button) return;

        uiButton.ButtonImage.color = hoverColor;
    }

    public void Unhover(UIButton uiButton)
    {
        if(uiButton == button) return;

        uiButton.ButtonImage.color = normalColor;
    }

    public void ResetButton()
    {

    }
}
