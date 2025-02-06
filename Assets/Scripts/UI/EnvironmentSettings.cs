using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSettings : MonoBehaviour
{
    [SerializeField] private Slider skyboxRotationSlider;

    private void Start()
    {
        EnvironmentManager.Instance.OnSkyboxChange += Reset;
    }

    private void OnDestroy()
    {
        EnvironmentManager.Instance.OnSkyboxChange -= Reset;
    }

    public void Reset()
    {
        skyboxRotationSlider.value = 0;
    }

    public void SkyboxSlider(float rotation)
    {
        EnvironmentManager.Instance.SetSkyboxRotation(rotation);
    }
}
