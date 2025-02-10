using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected UIManager uIManager;
    [SerializeField] protected Image buttonImage;

    public Image ButtonImage => buttonImage;

    public Action<UIButton> OnSelect;
    public Action<UIButton> OnDeselect;
    public Action<UIButton> OnHover;
    public Action<UIButton> OnUnhover;

    [SerializeField] private UnityEvent events;

    protected virtual void Start()
    {
        if(uIManager != null)
        {
            OnSelect += uIManager.Select;
            OnDeselect += uIManager.Deselect;
            OnHover += uIManager.Hover;
            OnUnhover += uIManager.Unhover;

            OnUnhover?.Invoke(this);
        }
    }

    protected virtual void OnDestroy()
    {
        if(uIManager != null)
        {
            OnSelect -= uIManager.Select;
            OnDeselect -= uIManager.Deselect;
            OnHover -= uIManager.Hover;
            OnUnhover -= uIManager.Unhover;
        }
    }

    public void ResetUIButton()
    {
        OnSelect?.Invoke(this);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        OnSelect?.Invoke(this);
        events?.Invoke();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.Input.ModelView.Disable();
        GameManager.Instance.Input.UI.Enable();

        OnHover?.Invoke(this);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.Input.UI.Disable();
        GameManager.Instance.Input.ModelView.Enable();

        OnUnhover?.Invoke(this);
    }
}
