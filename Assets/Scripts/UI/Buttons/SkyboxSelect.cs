using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkyboxSelect : UIButton
{
    [SerializeField] SkyboxType skyboxType;

    public Action<SkyboxType> OnEnvironmentSelect;

    private void Start()
    {
        OnEnvironmentSelect += EnvironmentManager.Instance.SelectEnvironment;
    }

    private void OnDestroy()
    {
        OnEnvironmentSelect -= EnvironmentManager.Instance.SelectEnvironment;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        OnEnvironmentSelect?.Invoke(skyboxType);
    }
}
