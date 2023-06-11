using System;
using UnityEngine;

namespace Glotonman2.Scenario.Items
{
    public class Speed : Bonus
    {
        public int m_SpeedBoost = 40;
        private new void Start()
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
                m_OnPlayerCollected?.Invoke(m_SpeedBoost, m_BonusTime);
        }
    }
}