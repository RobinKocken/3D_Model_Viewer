using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModelSettings : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text modelName;
    [SerializeField] private TMP_Text artistName;

    private void Start()
    {
        ModelManager.Instance.OnModelSpawned += SetModel;
    }

    private void OnDestroy()
    {
        ModelManager.Instance.OnModelSpawned -= SetModel;
    }

    public void SetModel(ModelData modelData, GameObject model)
    {
        modelName.text = modelData.ModelName;
        artistName.text = $"by {modelData.Artist}";
    }
}
