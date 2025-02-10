using UnityEngine;
using UnityEngine.UI;

public class MultiShaderController : MonoBehaviour
{
    // Lava Shader
    public Material lavaMaterial;
    public Slider lavaSlider;

    // Hex Barrier Shader
    public Material hexBarrierMaterial;
    public Slider hexScale;
    public Slider hexColor;

    void Start()
    {
        lavaSlider.onValueChanged.AddListener(UpdateLavaGlow);
        hexScale.onValueChanged.AddListener(UpdateHexScale);
        hexColor.onValueChanged.AddListener(UpdateHexColor);
    }

    public void UpdateLavaGlow(float value)
    {
        Debug.Log("Lava Glow Intensity: " + value);
        lavaMaterial.SetFloat("_EmissionIntensity", value);
    }

    public void UpdateHexScale(float value)
    {
        Debug.Log("Hex Barrier Property 1: " + value);
        hexBarrierMaterial.SetFloat("_HexScale", value);
    }

    public void UpdateHexColor(float value)
    {
        Debug.Log("Hex Barrier Property 2: " + value);
        hexBarrierMaterial.SetFloat("_ColorSpec", value);
    }
}
