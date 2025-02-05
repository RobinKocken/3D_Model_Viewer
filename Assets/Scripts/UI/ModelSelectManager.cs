using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelectManager : MonoBehaviour
{
    [SerializeField] private List<ModelData> modelDatas;

    [SerializeField] private GameObject modelSelectPrefab;
    [SerializeField] private RectTransform content;

    private void Start()
    {
        InitializeModelSelection();
    }

    private void InitializeModelSelection()
    {
        for(int i = 0; i < modelDatas.Count; i++)
        {
            GameObject select = Instantiate(modelSelectPrefab, content);

            if(select.TryGetComponent<ModelSelect>(out ModelSelect modelSelect))
            {
                modelSelect.SetModelSelect(modelDatas[i]);
            }
        }
    }
}
