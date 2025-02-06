using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    [SerializeField] private Volume volume;
    [SerializeField] private VolumeProfile dayProfile;
    [SerializeField] private VolumeProfile nightProfile;

    public Action OnSkyboxChange;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SelectSkybox(SkyboxType.Day);
    }

    public void SelectSkybox(SkyboxType environmentType)
    {
        switch(environmentType)
        {
            case SkyboxType.Day:
            {
                volume.profile = dayProfile;

                if(volume.profile.TryGet<HDRISky>(out HDRISky sky))
                {
                    sky.rotation.value = 0;
                }

                OnSkyboxChange?.Invoke();

                break;
            }
            case SkyboxType.Night:
            {
                volume.profile = nightProfile;

                if(volume.profile.TryGet<HDRISky>(out HDRISky sky))
                {
                    sky.rotation.value = 0;
                }

                OnSkyboxChange?.Invoke();

                break;
            }
        }
    }

    public void SetSkyboxRotation(float rotation)
    {
        if(volume.profile.TryGet<HDRISky>(out HDRISky sky))
        {
            sky.rotation.value = rotation;
        }
    }
}

public enum SkyboxType
{
    Day,
    Night,
}
