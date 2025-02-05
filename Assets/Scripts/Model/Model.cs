using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ModelData modelData;

    [SerializeField] private MaterialType materialType;
    [SerializeField] private List<MaterialHolder> materialsHolders;

    public void SwitchMaterials(MaterialType materialType)
    {
        for(int i = 0; i < materialsHolders.Count; i++)
        {
            switch(materialType)
            {
                case MaterialType.Lit:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].litMaterial;

                    break;
                }
                case MaterialType.Base:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].baseMaterial;

                    break;
                }
                case MaterialType.Normal:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].normalMaterial;

                    break;
                }
                case MaterialType.Mask:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].maskMaterial;

                    break;
                }
            }
        }
    }

    public void ApplyMaterial(Material material)
    {

    }

    [System.Serializable]
    public class MaterialHolder
    {
        public MeshRenderer meshRenderer;

        public Material litMaterial;
        public Material baseMaterial;
        public Material normalMaterial;
        public Material maskMaterial;
    }
}

public enum MaterialType
{
    Lit,
    Base,
    Normal,
    Mask,
}
