using Assets.Movers;
using UnityEngine;

public class CameraMoveControl : MonoBehaviour
{
    private readonly float cameraSpeed = 20f;
    private static readonly LaunchSequence launchSequence = new LaunchSequence();
    public static bool isLaunchingSequence = true;
    public static bool hasLaunched;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasLaunched) return;
        if (isLaunchingSequence) return;
        // If Right Button is clicked Camera will move.
        if (!Input.GetButton("Fire2")) return;
        var h = -cameraSpeed*Input.GetAxis("Mouse Y");
        var v = cameraSpeed*Input.GetAxis("Mouse X");
        transform.Rotate(h, v, 0);
    }

    private void FixedUpdate()
    {
        if (!hasLaunched) return;
        if (isLaunchingSequence)
        {
            launchSequence.Move(gameObject);
        }
        else
        {
            var moveVertical = Input.GetAxis("Vertical");
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.velocity = transform.forward*moveVertical*SpeedController.shipSpeed;
        }
    }
}