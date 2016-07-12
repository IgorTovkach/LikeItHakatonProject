using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Newton : MonoBehaviour
{
    private static List<NewtonBody> bodies;
    private static Vector3 acceleration;
    private static Vector3 direction;
    private static float fixedDeltaTime;

    private static Newton self;

    // Gravitational constant
    public float g = 0.01f;

    private void Start()
    {
        self = this;
        var sun = Resources.Load("Sun") as GameObject;
        sun = Instantiate(sun);
        CommonObjects.Sun = sun;
        var mercury = Resources.Load("Mercury") as GameObject;
        mercury = Instantiate(mercury);
        CommonObjects.Mercury = mercury;
        var venus = Resources.Load("Venus") as GameObject;
        venus = Instantiate(venus);
        CommonObjects.Venus = venus;
        var earth = Resources.Load("Earth") as GameObject;
        earth = Instantiate(earth);
        CommonObjects.Earth = earth;
        var mars = Resources.Load("Mars") as GameObject;
        mars = Instantiate(mars);
        CommonObjects.Mars = mars;
        var jupiter = Resources.Load("Jupiter") as GameObject;
        jupiter = Instantiate(jupiter);
        CommonObjects.Jupiter = jupiter;
        var saturn = Resources.Load("Saturn") as GameObject;
        saturn = Instantiate(saturn);
        CommonObjects.Saturn = saturn;
        var uranus = Resources.Load("Uranus") as GameObject;
        uranus = Instantiate(uranus);
        CommonObjects.Uranus = uranus;
        var neptune = Resources.Load("Neptune") as GameObject;
        neptune = Instantiate(neptune);
        CommonObjects.Neptune = neptune;


        var soyuz = Resources.Load("Camera") as GameObject;
        soyuz = Instantiate(soyuz);
        soyuz.transform.parent = earth.transform.GetChild(0);
        soyuz.transform.localPosition = new Vector3(0, 0.0013f, 0.5301f);

        CommonObjects.Rocket = soyuz.transform.GetChild(0).gameObject;
        CommonObjects.RocketCamera = soyuz;

        NewtonSetup();
        var ui = Resources.Load("UiLayout");
        Instantiate(ui);
    }

    private void FixedUpdate()
    {
        foreach (var body in bodies)
        {
            NewtonUpdate(body);
        }
    }

    private static void NewtonSetup()
    {
        fixedDeltaTime = Time.fixedDeltaTime;

        bodies = new List<NewtonBody>();
        bodies.AddRange(FindObjectsOfType(typeof(NewtonBody)) as NewtonBody[]);

        Debug.Log("There are probably " + bodies.Count + " Newton bodies in space (±42).");

        foreach (var body in bodies)
        {
            body.velocity = body._transform.TransformDirection(body.initialForwardSpeed);
        }
    }

    private static void NewtonUpdate(NewtonBody body)
    {
        acceleration = Vector3.zero;

        foreach (var otherBody in bodies)
        {
            if (body == otherBody)
            {
                continue;
            }
            direction = (otherBody._transform.position - body._transform.position);
            acceleration += self.g * (direction.normalized * otherBody.mass) / direction.sqrMagnitude;
        }

        body.velocity += acceleration * fixedDeltaTime;
        body._transform.position += body.velocity * fixedDeltaTime;
    }
}