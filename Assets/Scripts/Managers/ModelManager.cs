using System;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public static ModelManager Instance;

    [Header("Model Spawn")]
    private ModelData modelData;
    private Model model;
    [SerializeField] private Vector3 spawnPos; 

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

        if(model != null)
            Destroy(model.gameObject);

        GameObject newModel = Instantiate(modelData.ModelPrefab, spawnPos, Quaternion.identity);

        if(newModel.TryGetComponent<Model>(out Model component))
        {
            model = component;
        }

        OnModelSpawned?.Invoke(modelData, newModel);
    }

    public void SwitchModelMaterial(MaterialType materialType)
    {
        model.SwitchMaterials(materialType);
    }
}
