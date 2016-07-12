using System;
using UnityEngine;

namespace Assets.Movers
{
    public class LaunchSequence : IMover
    {
        private float rotation = 5f;
        private const float TiltSpeed = 0.3f;
        private float FinalRotation = 90;
        public void Move(GameObject gameObject)
        {
            if (SpeedController.shipSpeed<TiltSpeed)
            {
                StartMove(gameObject);
                return;
            }
            if (gameObject.transform.localEulerAngles.z<FinalRotation)
            {
                StartMove(gameObject);
                TiltMove(gameObject);
                return;
            }
            EndMove(gameObject);
        }

        private void StartMove(GameObject gameObject)
        {
            SpeedController.shipSpeed += 0.1f;
        }

        private void TiltMove(GameObject gameObject)
        {
            gameObject.transform.Rotate(0,0,rotation);
            gameObject.transform.localEulerAngles += new Vector3(0,0,rotation);
        }

        public void EndMove(GameObject gameObject)
        {
            gameObject.transform.parent = null;
            CameraMoveControl.isLaunchingSequence = false;
        }
    }
}