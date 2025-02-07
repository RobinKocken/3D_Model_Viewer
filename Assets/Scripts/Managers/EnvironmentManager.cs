using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    [SerializeField] private Volume volume;
    //[SerializeField] private Light sun;
    [SerializeField] private HDAdditionalLightData sun;

    [SerializeField] private List<EnvironmentHolder> environmentHolders;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SelectSkybox(EnvironmentType.Day);
    }

    public void SelectSkybox(EnvironmentType environmentType)
    {
        for(int i = 0; i < environmentHolders.Count; i++)
        {
            if(environmentHolders[i].environmentType != environmentType) continue;

            volume.profile = environmentHolders[i].profile;
            sun.GetComponent<Light>().colorTemperature = environmentHolders[i].temperature;
            sun.intensity = environmentHolders[i].intensity;

            return;
        }
    }

    public void SetSunRotation(float rotation)
    {
        sun.transform.rotation = Quaternion.Euler(new Vector3(sun.transform.eulerAngles.x, rotation, sun.transform.eulerAngles.z));
    }

    [Serializable]
    public class EnvironmentHolder
    {
        public EnvironmentType environmentType;
        public VolumeProfile profile;
        public float temperature;
        public float intensity;
    }
}

public enum EnvironmentType
{
    Normal,
    Day,
    Night,
}
