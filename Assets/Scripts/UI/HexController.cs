using UnityEngine;
using UnityEngine.UI;

public class HexController : MonoBehaviour
{
  
    // Hex Barrier Shader
    public Material hexBarrierMaterial;
    public Slider hexScale;
    public Slider hexColor;

    void Start()
    {
        hexScale.onValueChanged.AddListener(UpdateHexScale);
        hexColor.onValueChanged.AddListener(UpdateHexColor);
    }

    public void UpdateHexScale(float value)
    {
        hexBarrierMaterial.SetFloat("_HexScale", value);
    }

    public void UpdateHexColor(float value)
    {
        hexBarrierMaterial.SetFloat("_ColorSpec", value);
    }
}
