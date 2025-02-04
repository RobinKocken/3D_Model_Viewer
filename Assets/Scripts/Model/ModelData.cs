using UnityEngine;

[CreateAssetMenu(menuName = "Model", fileName = "ModelData")]
public class ModelData : ScriptableObject
{
    [SerializeField] private string modelName;
    [TextArea(4, 0)]
    [SerializeField] private string description;
    [SerializeField] private string artist;
    [SerializeField] private GameObject model;

    public string ModelName => modelName;
    public string Description => description;
    public string Artist => artist;
    public GameObject Model => model;
}
