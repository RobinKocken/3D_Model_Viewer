using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSettings : MonoBehaviour
{
    [SerializeField] private Slider sunRotationSlider;

    public void SkyboxSlider(float rotation)
    {
        EnvironmentManager.Instance.SetSunRotation(rotation);
    }
}
