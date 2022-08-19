using System;
using System.Text;
using System.Text.RegularExpressions;
using DefaultNamespace.Extensions;
using UnityEngine;

namespace DefaultNamespace.Test
{
    public class CheckString : MonoBehaviour
    {
        [ContextMenu("Check")]
        public void Check()
        {
            string message = "DualShock4GamepadHID";
            //message = message.ToLower();

            string sample = "gamepad";

            bool isMatch = message.IsMatch(sample);
            
            Debug.Log(isMatch);


        }
    }
}