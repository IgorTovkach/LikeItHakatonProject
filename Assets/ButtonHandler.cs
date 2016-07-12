using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var button = gameObject.GetComponent(typeof (Button)) as Button;
        if (button != null)
            button.onClick.AddListener(() =>
            {
                var findGameObjectWithTag = GameObject.FindGameObjectWithTag("Player");
                if (findGameObjectWithTag == null) return;
                if (findGameObjectWithTag.GetComponents(typeof(Autopilot)).Length!=0) return;
                var autopilot = findGameObjectWithTag.AddComponent(typeof (Autopilot)) as Autopilot;
                if (autopilot != null)
                    autopilot.Target = GameObject.Find(gameObject.name);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
