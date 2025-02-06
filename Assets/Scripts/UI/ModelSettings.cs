using TMPro;
using UnityEngine;

public class ModelSettings : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text modelName;
    [SerializeField] private TMP_Text artistName;
    [SerializeField] private TMP_Text trisText;

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

        float vertCount = 0;
        float triCount = 0;

        if(model.TryGetComponent<Model>(out Model component))
        {
            for(int i = 0; i < component.MaterialHolders.Count; i++)
            {
                triCount += component.MaterialHolders[i].meshRenderer.GetComponent<MeshFilter>().mesh.triangles.Length / 3;
            }
        }

        trisText.text = $"Triangles: {triCount}";
    }
}
