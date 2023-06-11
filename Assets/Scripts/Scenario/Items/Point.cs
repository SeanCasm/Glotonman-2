using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glotonman2.Scenario.Items
{
    public class Point : Bonus
    {
        public float m_PointsMultiplier = .5f;
        new void Start()
        {
            base.Start();
        }
        private new void OnAnimationDisable()
        {
            base.OnAnimationDisable();
        }
        private new void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag("Player"))
                m_OnPlayerCollected?.Invoke(m_PointsMultiplier, m_BonusTime);
        }

    }
}
