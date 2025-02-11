using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public static ModelManager Instance;

    [Header("Model Spawn")]
    private ModelData modelData;
    private Model model;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private float disolveSpeed;
    [SerializeField] private Vector2 disolveTargetPos;

    public Action<ModelData, GameObject> OnModelSpawned;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SelectModel(ModelData modelData)
    {
        this.modelData = modelData;

        StartCoroutine(ModelDisolve(model != null));
    }

    private IEnumerator ModelDisolve(bool destroyModel)
    {
        bool run = destroyModel;
        List<float> disolveValue = new List<float>(0);
        int count = 0; 

        if(run)
        {
            count = model.MaterialHolders.FindAll(x => x.switchMaterial == true).Count;
            disolveValue = new List<float>(new float[count]);

            for(int i = 0; i < model.MaterialHolders.Count; i++)
            {
                if(model.MaterialHolders[i].switchMaterial == false) continue;

                model.MaterialHolders[i].meshRenderer.material = model.MaterialHolders[i].disolveShader;
                model.MaterialHolders[i].disolveShader.SetFloat("_Disolve", disolveTargetPos.x);
            }
        }

        while(run)
        {
            for(int i = 0; i < model.MaterialHolders.Count; i++)
            {
                if(model.MaterialHolders[i].switchMaterial == false) continue;

                disolveValue[i] = Mathf.Lerp(model.MaterialHolders[i].disolveShader.GetFloat("_Disolve"), disolveTargetPos.y, disolveSpeed * Time.deltaTime);
                model.MaterialHolders[i].disolveShader.SetFloat("_Disolve", disolveValue[i]);

                if(MathF.Abs(disolveValue[i] - disolveTargetPos.y) < 0.1f)
                {
                    disolveValue[i] = disolveTargetPos.y;
                    model.MaterialHolders[i].disolveShader.SetFloat("_Disolve", disolveValue[i]);
                }
            }

            if(disolveValue.Count == disolveValue.FindAll(x => x == disolveTargetPos.y).Count)
            {
                run = false;
                Destroy(model.gameObject);
            }

            yield return new WaitForEndOfFrame();
        }

        GameObject newModel = Instantiate(modelData.ModelPrefab, spawnPos, Quaternion.identity);

        if(newModel.TryGetComponent<Model>(out Model component))
        {
            model = component;
        }

        bool run2 = true;
        count = model.MaterialHolders.FindAll(x => x.switchMaterial == true).Count;
        disolveValue = new List<float>(new float[count]);

        for(int i = 0; i < model.MaterialHolders.Count; i++)
        {
            if(model.MaterialHolders[i].switchMaterial == false) continue;

            model.MaterialHolders[i].meshRenderer.material = model.MaterialHolders[i].disolveShader;
            model.MaterialHolders[i].disolveShader.SetFloat("_Disolve", disolveTargetPos.y);
        }

        while(run2)
        {
            for(int i = 0; i < model.MaterialHolders.Count; i++)
            {
                if(model.MaterialHolders[i].switchMaterial == false) continue;

                disolveValue[i] = Mathf.Lerp(model.MaterialHolders[i].disolveShader.GetFloat("_Disolve"), disolveTargetPos.x, disolveSpeed * Time.deltaTime);
                model.MaterialHolders[i].disolveShader.SetFloat("_Disolve", disolveValue[i]);

                if(MathF.Abs(disolveValue[i] - disolveTargetPos.x) < 0.1f)
                {
                    disolveValue[i] = disolveTargetPos.x;
                    model.MaterialHolders[i].disolveShader.SetFloat("_Disolve", disolveValue[i]);
                }
            }

            if(disolveValue.Count == disolveValue.FindAll(x => x == disolveTargetPos.x).Count)
            {
                for(int i = 0; i < model.MaterialHolders.Count; i++)
                {
                    if(model.MaterialHolders[i].switchMaterial == false) continue;

                    model.MaterialHolders[i].meshRenderer.material = model.MaterialHolders[i].litMaterial;
                }

                OnModelSpawned?.Invoke(modelData, newModel);

                run2 = false;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void SwitchModelMaterial(MaterialType materialType)
    {
        if(model == null) return;

        model.SwitchMaterials(materialType);
    }
}
