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
        {
            button.ButtonImage.color = normalColor;
            button.OnDeselectEvents?.Invoke();
        }

        button = uiButton;
        button.ButtonImage.color = selectedColor;
        button.OnSelectEvents?.Invoke();
    }

    public void Deselect(UIButton uiButton)
    {
        if(uiButton != button) return;

        button.ButtonImage.color = normalColor;
        button = null;
        button.OnDeselectEvents?.Invoke();
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
}
