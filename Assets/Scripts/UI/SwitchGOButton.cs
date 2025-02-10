using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchGOButton : UIButton
{
    [SerializeField] private List<GameObject> switchObjects;

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        for(int i = 0; i < switchObjects.Count; i++)
        {
            if(switchObjects[i].activeSelf == true)
            {
                switchObjects[i].SetActive(false);

                int nextIndex = 1;

                if(i + 1 >= switchObjects.Count)
                {
                    nextIndex = -i;
                }

                switchObjects[i + nextIndex].SetActive(true);

                return;
            }
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        OnDeselect?.Invoke(this);
    }
}
