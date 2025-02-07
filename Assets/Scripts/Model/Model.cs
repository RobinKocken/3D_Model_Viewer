using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ModelData modelData;

    [SerializeField] private List<MaterialHolder> materialsHolders;
    public List<MaterialHolder> MaterialHolders => materialsHolders;

    public void SwitchMaterials(MaterialType materialType)
    {
        for(int i = 0; i < materialsHolders.Count; i++)
        {
            if(materialsHolders[i].switchMaterial == false) continue;

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
                case MaterialType.Uv:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].uvShader;

                    break;
                }
                case MaterialType.Holo:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].holoShader;

                    break;
                }
                case MaterialType.Toon:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].toonShader;

                    break;
                }
                case MaterialType.Hex:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].hexShader;

                    break;
                }
                case MaterialType.Lava:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].lavaShader;

                    break;
                }
                case MaterialType.Pixel:
                {
                    materialsHolders[i].meshRenderer.material = materialsHolders[i].pixelShader;

                    break;
                }
            }
        }
    }

    [System.Serializable]
    public class MaterialHolder
    {
        public MeshRenderer meshRenderer;

        public bool switchMaterial = true;
        public Material litMaterial;
        public Material baseMaterial;
        public Material normalMaterial;
        public Material maskMaterial;
        [Space]
        public Material uvShader;
        public Material holoShader;
        public Material toonShader;
        public Material hexShader;
        public Material lavaShader;
        public Material pixelShader;
    }
}

public enum MaterialType
{
    Lit,
    Base,
    Normal,
    Mask,
    Uv,
    Holo,
    Toon,
    Hex,
    Lava,
    Pixel,
}
