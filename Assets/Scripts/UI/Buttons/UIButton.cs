using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.Input.ModelView.Disable();
        GameManager.Instance.Input.UI.Enable();

    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.Input.UI.Disable();
        GameManager.Instance.Input.ModelView.Enable();
    }
}
