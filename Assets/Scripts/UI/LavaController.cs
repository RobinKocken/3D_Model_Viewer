using UnityEngine;
using UnityEngine.UI;

public class LavaController : MonoBehaviour
{
    // Lava Shader
    public Material lavaMaterial;
    public Slider lavaSlider;

 
    void Start()
    {
        lavaSlider.onValueChanged.AddListener(UpdateLavaGlow);
    }

    public void UpdateLavaGlow(float value)
    {
        lavaMaterial.SetFloat("_EmissionIntensity", value);
    }

}
