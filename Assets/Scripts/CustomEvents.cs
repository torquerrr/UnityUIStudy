using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Kube
{
    public class CustomEvents : MonoBehaviour
    {
        public Transform kube;
        public Text speedometer;
        private Rigidbody rb;
        private ConstantForce cf;

        // custom event
        // public delegate void FreeFall();
        // public static event FreeFall OnFreeFallReached;

        // with UnityEvent
        public static FallEvent OnTerminalSpeedReached = new FallEvent();

        public NewEvent evnt;

        private bool eventFired = false;

        void Start()
        {
            rb = kube?.GetComponent<Rigidbody>();
            cf = kube?.GetComponent<ConstantForce>();
        }

        void Update()
        {
            this.transform.LookAt(kube);
            speedometer.text = $"Fall Speed is: {Mathf.Abs(rb.velocity.y)} m/s";

            // F = 0.5 * rho * C * A * V**2
            // calculating air resistance force
            float airRes = 0.5f * 0.8f * 0.45f * 1 * Mathf.Pow(rb.velocity.y, 2.0f);

            // add the force to ConstantForce component
            cf.force = new Vector3(0, airRes, 0);

            if (Mathf.Abs(rb.velocity.y) > 60 && OnTerminalSpeedReached != null)
            {
                if (!eventFired)
                {
                    // calling first callback
                    OnTerminalSpeedReached.Invoke("Terminal speed was reached!");

                    // calling second callback
                    evnt.Invoke(10, 20.0f);
                }
                eventFired = true;
            }
        }

        // defining custom event
        public class FallEvent : UnityEvent<string> { }
        [System.Serializable] public class NewEvent : UnityEvent<int, float> { }
    }
}
