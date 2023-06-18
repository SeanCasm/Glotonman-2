using UnityEngine;
using Glotonman2.Data;

namespace Glotonman2.Scenario.Items
{
    public class Fruit : Item
    {
        [Header("Stats")]
        public int m_HungryIncrement = 10;
        public ItemGenerator itemGenerator { get; set; }
        public PlayerStats gameData { get; set; }
        private bool instantiatedFlag;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                base.OnCollisionWithPlayer();
                gameData.UpdateHungry(m_HungryIncrement);
            }
        }
        private void OnDisable()
        {
            if (instantiatedFlag)
                itemGenerator.EnqueueFruit(this);
            instantiatedFlag = true;
        }
    }
}