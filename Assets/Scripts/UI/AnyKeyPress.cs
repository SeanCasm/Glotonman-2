using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Glotonman2.InputKey
{
    public class AnyKeyPress : MonoBehaviour
    {
        public UnityEvent m_PressActions;
        private void Update()
        {
            if (Input.anyKeyDown)
                KeyPressed();
        }
        public void KeyPressed() => m_PressActions?.Invoke();
    }
}
