using UnityEngine;
using Glotonman2.Data;
using Glotonman2.Scenario.Items;

namespace Glotonman2.Scenario
{
    public class ScenarioLimiter : MonoBehaviour
    {
        public PlayerStats m_PlayerStats;
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                m_PlayerStats.DecrementLives();
            else if (other.CompareTag("Item"))
                other.GetComponent<Item>().OnCollisionDisable();
        }
    }
}