using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialSelect : UIButton
{
    [SerializeField] private MaterialType materialType;

    public Action<MaterialType> OnMaterialSelect;

    private void Start()
    {
        OnMaterialSelect += ModelManager.Instance.SwitchModelMaterial;
    }

    private void OnDestroy()
    {
        OnMaterialSelect -= ModelManager.Instance.SwitchModelMaterial;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        OnMaterialSelect?.Invoke(materialType);
    }
}
