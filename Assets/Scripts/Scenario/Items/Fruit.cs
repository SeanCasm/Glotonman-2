using UnityEngine;
using Glotonman2.Data;

namespace Glotonman2.Scenario.Items
{
    public class Fruit : Item
    {
        [Header("Stats")]
        public int m_HungryDecrement = -10;
        public ItemGenerator itemGenerator { get; set; }
        public PlayerStats gameData { get; set; }
        private bool instantiatedFlag;
        private new void OnAnimationDisable()
        {
            base.OnAnimationDisable();
        }
        private new void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag("Player"))
                gameData.UpdateHungry(m_HungryDecrement);
        }
        private void OnDisable()
        {
            if (instantiatedFlag)
                itemGenerator.EnqueueFruit(this);
            instantiatedFlag = true;
        }
    }
}