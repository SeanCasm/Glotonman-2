using UnityEngine;

namespace Glotonman2.Scenario.Items
{
    public class Point : Item
    {
        public float m_PointsMultiplier = .5f;

        new void Start()
        {
            base.Start();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                base.OnCollisionWithPlayer();
                m_OnPlayerCollected?.Invoke(m_PointsMultiplier, m_BonusTime);
            }
        }

    }
}
