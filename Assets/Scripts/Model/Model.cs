using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ModelData modelData;

    [SerializeField] private List<MaterialHolder> materialsHolders;

    private void Start()
    {

    }

    public void SwitchMaterials()
    {
        for(int i = 0; i < materialsHolders.Count; i++)
        {
            
        }
    }

    [System.Serializable]
    public class MaterialHolder
    {
        public MeshRenderer meshRenderer;

        public Material litMaterial;
        public Material unlitMaterial;
    }
}
