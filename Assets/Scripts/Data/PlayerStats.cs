using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Glotonman2.Data
{
    public class PlayerStats : MonoBehaviour
    {
        public int m_Lives;
        public UnityEvent m_OnDeath;
        public UnityEvent m_Hurt;
        public Glotonman2.UI.Stats m_Stats;
        public const int m_MaxHungry = 100;
        private int score = 0, lives = 2, hungry = 0;
        private float scoreMultiplier = 1;

        public void DecrementLives()
        {
            lives--;
            m_Stats.ChangeLives(lives);
            m_Hurt?.Invoke();
            if (lives <= 0)
            {
                if (lives == 0)
                    m_OnDeath?.Invoke();
            }
        }
        public void IncrementScore(int amount)
        {
            score += Mathf.RoundToInt(amount * scoreMultiplier);
            m_Stats.ChangeScore(score);
        }
        public void IncrementScoreMultiplier(float amount, int time)
        {
            scoreMultiplier = amount;
            Invoke(nameof(SetDefaultScore), time);

            void SetDefaultScore() => scoreMultiplier = 1;
        }
        public void UpdateHungry(int amount)
        {
            hungry += amount;
            switch (hungry)
            {
                case >= m_MaxHungry:
                    hungry = 0;
                    DecrementLives();
                    break;
                case <= 0:
                    hungry = 0;
                    break;
            }
            m_Stats.ChangeHungry(hungry);
        }
    }

}
