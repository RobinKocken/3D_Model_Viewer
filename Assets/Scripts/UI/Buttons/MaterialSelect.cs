using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialSelect : UIButton
{
    [SerializeField] private MaterialType materialType;

    public Action<MaterialType> OnMaterialSelect;

    protected override void Start()
    {
        base.Start();

        OnMaterialSelect += ModelManager.Instance.SwitchModelMaterial;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        OnMaterialSelect -= ModelManager.Instance.SwitchModelMaterial;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        OnMaterialSelect?.Invoke(materialType);
    }
}
