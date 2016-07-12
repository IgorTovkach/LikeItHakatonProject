using System;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlanetUiScript : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var texts = GetComponentsInChildren<Text>().Where(x => x.name != "Text").ToArray();
        foreach (var text in texts)
        {
            var childTexts = text.GetComponentsInChildren<Text>().ToArray();
            childTexts[1].text = GetVectorString(text.name);
        }
    }

    private string GetVectorString(string planet)
    {
        switch (planet)
        {
            case "Sun":
                return CommonObjects.Sun.transform.position.ToString();
            case "Mercury":
                return CommonObjects.Mercury.transform.position.ToString();
            case "Venus":
                return CommonObjects.Venus.transform.position.ToString();
            case "Earth":
                return CommonObjects.Earth.transform.position.ToString();
            case "Mars":
                return CommonObjects.Mars.transform.position.ToString();
            case "Jupiter":
                return CommonObjects.Jupiter.transform.position.ToString();
            case "Saturn":
                return CommonObjects.Saturn.transform.position.ToString();
            case "Uranus":
                return CommonObjects.Uranus.transform.position.ToString();
            case "Neptune":
                return CommonObjects.Neptune.transform.position.ToString();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}