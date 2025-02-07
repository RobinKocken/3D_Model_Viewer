using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkyboxSelect : UIButton
{
    [SerializeField] EnvironmentType skyboxType;

    public Action<EnvironmentType> OnEnvironmentSelect;

    protected override void Start()
    {
        base.Start();

        OnEnvironmentSelect += EnvironmentManager.Instance.SelectSkybox;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        OnEnvironmentSelect -= EnvironmentManager.Instance.SelectSkybox;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        OnEnvironmentSelect?.Invoke(skyboxType);
    }
}
