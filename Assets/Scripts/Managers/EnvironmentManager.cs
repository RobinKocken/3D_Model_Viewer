using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
