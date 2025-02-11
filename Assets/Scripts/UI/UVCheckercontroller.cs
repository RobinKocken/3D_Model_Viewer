using UnityEngine;
using UnityEngine.UI;

public class UVCheckercontroller : MonoBehaviour
{

    public Material uvchecker;
    public Slider uvcheckerscaleslider;


    void Start()
    {
        uvcheckerscaleslider.onValueChanged.AddListener(UpdateUVScale);
    }
    public void UpdateUVScale(float value)
    {
        uvchecker.SetFloat("_uvtiling", value);
    }

}
