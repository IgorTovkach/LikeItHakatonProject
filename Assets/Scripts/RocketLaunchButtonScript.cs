using UnityEngine;
using UnityEngine.UI;

public class RocketLaunchButtonScript : MonoBehaviour
{
    private void Start()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            CameraMoveControl.hasLaunched = true;
            gameObject.transform.parent.Rotate(0, 90, 0);
        });
    }
}