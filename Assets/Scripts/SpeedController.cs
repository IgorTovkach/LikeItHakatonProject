using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    public static float shipSpeed;
    public static float maxShipSpeed = 1000f;
    private Slider slider;


    // Use this for initialization
    private void Start()
    {
        slider = gameObject.GetComponentInChildren<Slider>();
        slider.onValueChanged.AddListener(f => shipSpeed = f * maxShipSpeed);
    }
}