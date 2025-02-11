using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelSelectManager : MonoBehaviour
{
    [SerializeField] private List<ModelData> modelDatas;

    [Header("UI")]
    [SerializeField] private UIManager uIManager;
    [SerializeField] private GameObject modelSelectPrefab;
    [SerializeField] private RectTransform content;
    [SerializeField] private HorizontalLayoutGroup horizontalLayout;
    [SerializeField] private RectMask2D rectMask;
    [SerializeField] private ScrollRect scrollRect;

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
                modelSelect.SetModelSelect(modelDatas[i], uIManager, rectMask, horizontalLayout,scrollRect);
            }
        }
    }
}
