using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelSelect : UIButton
{
    [Header("Model Data")]
    [SerializeField] private ModelData modelData;

    [Header("UI")]
    [SerializeField] private TMP_Text modelName;

    public Action<ModelData> OnModelSelect;

    public void SetModelSelect(ModelData modelData)
    {
        this.modelData = modelData;

        modelName.text = modelData.ModelName;

        OnModelSelect += ModelManager.Instance.SelectModel;
    }

    private void OnDestroy()
    {
        OnModelSelect -= ModelManager.Instance.SelectModel;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        OnModelSelect?.Invoke(modelData);
    }
}
