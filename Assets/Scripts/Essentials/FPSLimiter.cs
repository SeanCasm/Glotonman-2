using System;
using System.Collections.Generic;
using UnityEngine;

namespace Glotonman2.Essentials
{
    public class FPSLimiter : MonoBehaviour
    {
        public int m_TargetFPS = 60;

        private void Start()
        {
            Application.targetFrameRate = m_TargetFPS;
        }
    }
}