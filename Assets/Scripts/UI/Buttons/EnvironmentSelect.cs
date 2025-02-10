using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnvironmentSelect : UIButton
{
    [SerializeField] EnvironmentType environmentType;

    public Action<EnvironmentType> OnEnvironmentSelect;

    protected override void Start()
    {
        base.Start();

        OnEnvironmentSelect += EnvironmentManager.Instance.SelectSkybox;

        if(environmentType == EnvironmentType.Normal)
            ResetUIButton();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        OnEnvironmentSelect -= EnvironmentManager.Instance.SelectSkybox;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        OnEnvironmentSelect?.Invoke(environmentType);
    }
}
