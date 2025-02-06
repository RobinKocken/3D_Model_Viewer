using UnityEngine;
using UnityEngine.Rendering;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    [SerializeField] private Volume volume;
    [SerializeField] private VolumeProfile dayProfile;
    [SerializeField] private VolumeProfile nightProfile;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SelectEnvironment(SkyboxType environmentType)
    {
        switch(environmentType)
        {
            case SkyboxType.Day:
            {
                volume.sharedProfile = dayProfile;

                break;
            }
            case SkyboxType.Night:
            {
                volume.sharedProfile = nightProfile;

                break;
            }
        }
    }
}

public enum SkyboxType
{
    Day,
    Night,
}
