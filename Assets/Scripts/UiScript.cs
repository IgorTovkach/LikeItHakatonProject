using System.Globalization;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        DisplayCoordinates();
    }

    private static void DisplayCoordinates()
    {
        var objects = FindObjectsOfType<GameObject>();
        var filtered = objects.Where(IsLabelSelector).ToArray();

        var rocket = CommonObjects.Rocket;
        var x = filtered[0].transform.GetChild(0).GetComponentInChildren<Text>();
        x.text = rocket.transform.position.z.ToString(CultureInfo.InvariantCulture);

        var y = filtered[1].transform.GetChild(0).GetComponentInChildren<Text>();
        y.text = rocket.transform.position.y.ToString(CultureInfo.InvariantCulture);

        var z = filtered[2].transform.GetChild(0).GetComponentInChildren<Text>();
        z.text = rocket.transform.position.x.ToString(CultureInfo.InvariantCulture);
    }

    private static bool IsLabelSelector(GameObject component)
    {
        return component.name.Contains("Coord") && !component.name.Contains("Value");
    }
}