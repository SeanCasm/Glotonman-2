using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Glotonman2.Scenario.Items
{
    public class Bonus : Item
    {
        public int m_BonusTime = 4;
        public float spawnProb = .2f;
        public UnityEvent<float, int> m_OnPlayerCollected;
    }
}