using UnityEngine;

namespace Glotonman2.Scenario.Items
{
    public class Speed : Item
    {
        public int m_SpeedBoost = 40;

        private new void Start()
        {
            base.Start();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                base.OnCollisionWithPlayer();
                m_OnPlayerCollected?.Invoke(m_SpeedBoost, m_BonusTime);
            }
        }
    }
}