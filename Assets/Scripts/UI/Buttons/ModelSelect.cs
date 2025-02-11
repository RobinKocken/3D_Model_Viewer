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
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform smallSize;
    [SerializeField] private RectTransform bigSize;

    [SerializeField] private TMP_Text modelName;
    [SerializeField] private TMP_Text modelDescriptionName;
    [SerializeField] private TMP_Text description;

    private RectMask2D rectMask;
    private HorizontalLayoutGroup horizontalLayout;
    private ScrollRect scrollRect;

    [SerializeField] private float sizeSpeed;
    [SerializeField] private Vector2 originalSize;
    [SerializeField] private Vector2 descriptionSize;

    public Action<ModelData> OnModelSelect;


    protected override void Start()
    {

    }

    protected override void OnDestroy()
    {
        OnModelSelect -= ModelManager.Instance.SelectModel;

        OnSelect -= uIManager.Select;
        OnDeselect -= uIManager.Deselect;
        OnHover -= uIManager.Hover;
        OnUnhover -= uIManager.Unhover;
    }

    public void SetModelSelect(ModelData modelData, UIManager uIManager, RectMask2D rectMask, HorizontalLayoutGroup horizontalLayout, ScrollRect scrollRect)
    {
        this.modelData = modelData;
        this.uIManager = uIManager;
        this.rectMask = rectMask;
        this.horizontalLayout = horizontalLayout;
        this.scrollRect = scrollRect;

        modelName.text = modelData.ModelName;
        modelDescriptionName.text = modelData.ModelName;
        description.text = modelData.Description;

        OnModelSelect += ModelManager.Instance.SelectModel;

        OnSelect += this.uIManager.Select;
        OnDeselect += this.uIManager.Deselect;
        OnHover += this.uIManager.Hover;
        OnUnhover += this.uIManager.Unhover;

        OnUnhover?.Invoke(this);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        OnModelSelect?.Invoke(modelData);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

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
        Vector3[] cornerPos = new Vector3[4];

        smallSize.gameObject.SetActive(!smallSize.gameObject.activeSelf);
        bigSize.gameObject.SetActive(!bigSize.gameObject.activeSelf);

        while(run)
        {
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, targetSize, sizeSpeed * Time.deltaTime);
            rectMask.padding = new Vector4(0, 0, 0, originalSize.y - rectTransform.sizeDelta.y);

            horizontalLayout.SetLayoutHorizontal();
            scrollRect.SetLayoutHorizontal();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)horizontalLayout.transform);

            rectTransform.GetWorldCorners(cornerPos);

            if(rectMask.rectTransform.rect.Contains(rectMask.rectTransform.InverseTransformPoint(cornerPos[0])) == false && bigSize.gameObject.activeSelf == true)
            {
                Debug.Log("Left");

                scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, 0, Time.deltaTime * 6);
            }

            if(rectMask.rectTransform.rect.Contains(rectMask.rectTransform.InverseTransformPoint(cornerPos[3])) == false && bigSize.gameObject.activeSelf == true)
            {
                Debug.Log("Right");

                scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, 1, Time.deltaTime * 6);
            }

            if(Vector2.Distance(rectTransform.sizeDelta, targetSize) < 0.1f)
            {
                run = false;

                rectTransform.sizeDelta = targetSize;
                rectMask.padding = new Vector4(0, 0, 0, originalSize.y - rectTransform.sizeDelta.y);

                horizontalLayout.SetLayoutHorizontal();
                LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)horizontalLayout.transform);

                yield return null;
            }

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}
