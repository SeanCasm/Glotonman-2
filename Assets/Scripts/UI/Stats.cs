using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
namespace Glotonman2.UI
{
    public class Stats : MonoBehaviour
    {
        public int m_MaxLives = 2;
        public TextMeshProUGUI m_Lives, m_Score, m_Best, m_Hungry;
        private void Start()
        {
            m_Lives.text = $"Lives\n{m_MaxLives}/{m_MaxLives}";
        }
        public void ChangeLives(int lives)
        {
            m_Lives.text = $"Lives\n{lives} / {m_MaxLives}";
        }
        public void ChangeScore(int score)
        {
            m_Score.text = $"Score\n{score}";
        }
        public void ChangeHungry(int hungry)
        {
            m_Hungry.text = $"Hungry\n{hungry}";
        }
        public void ChangeBest(int best)
        {
            m_Best.text = $"Best\n{best}";
        }

    }
}
