using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kube
{
    public class CustomMessage : MonoBehaviour
    {
        private void OnEnable()
        {
            CustomEvents.OnTerminalSpeedReached.AddListener(SendStatus);
        }

        private void OnDisable()
        {
            CustomEvents.OnTerminalSpeedReached.RemoveListener(SendStatus);
        }

        private void SendStatus(string status)
        {
            Debug.Log(status);
        }

        public void testEvent(int x, float y)
        {
            Debug.Log($"Your parameters are {x} and {y}");
        }
    }
}
