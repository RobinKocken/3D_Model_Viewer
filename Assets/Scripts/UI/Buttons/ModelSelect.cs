using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ModelSelect : UIButton
{
    [Header("Model Data")]
    [SerializeField] private ModelData modelData;

    [Header("UI")]
    [SerializeField] private RectTransform rect;
    [SerializeField] private RectTransform smallSize;
    [SerializeField] private RectTransform bigSize;

    [SerializeField] private TMP_Text modelName;
    [SerializeField] private TMP_Text description;


    private RectMask2D rectMask;
    private HorizontalLayoutGroup horizontalLayout;

    [SerializeField] private float sizeSpeed;
    [SerializeField] private Vector2 originalSize;
    [SerializeField] private Vector2 descriptionSize;

    public Action<ModelData> OnModelSelect;

    public void SetModelSelect(ModelData modelData, RectMask2D rectMask, HorizontalLayoutGroup horizontalLayout)
    {
        this.modelData = modelData;
        this.rectMask = rectMask;
        this.horizontalLayout = horizontalLayout;

        modelName.text = modelData.ModelName;
        description.text = modelData.Description;

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

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        Debug.Log("Pointer Enter");

        StopAllCoroutines();
        StartCoroutine(ModelSelectAnimation(descriptionSize));
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        StopAllCoroutines();
        StartCoroutine(ModelSelectAnimation(originalSize));
    }

    private IEnumerator ModelSelectAnimation(Vector2 targetSize)
    {
        bool run = true;

        smallSize.gameObject.SetActive(!smallSize.gameObject.activeSelf);
        bigSize.gameObject.SetActive(!bigSize.gameObject.activeSelf);

        while(run)
        {
            rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, targetSize, sizeSpeed * Time.deltaTime);
            rectMask.padding = new Vector4(0, 0, 0, originalSize.y - rect.sizeDelta.y);

            if(Vector2.Distance(rect.sizeDelta, targetSize) < 0.1f)
            {
                run = false;

                rect.sizeDelta = targetSize;
                rectMask.padding = new Vector4(0, 0, 0, originalSize.y - rect.sizeDelta.y);

                yield return null;
            }

            yield return new WaitForEndOfFrame();

            horizontalLayout.SetLayoutHorizontal();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)horizontalLayout.transform);
        }

        yield return null;
    }
}
