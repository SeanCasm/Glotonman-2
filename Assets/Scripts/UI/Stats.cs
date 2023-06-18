using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Glotonman2.UI
{
    public class Stats : MonoBehaviour
    {
        public int m_MaxLives = 2;
        public int m_MaxHungry = 10;
        public TextMeshProUGUI m_Score, m_Best;
        public Image m_Lives, m_Hungry;
        private void Start()
        {
            m_Score.text = 0.ToString();
            m_Lives.rectTransform.sizeDelta = new Vector2(16 * m_MaxLives, 16);
            m_Hungry.rectTransform.sizeDelta = new Vector2(16 * m_MaxHungry, 16);
        }
        public void ChangeLives(int lives)
        {
            float current = m_Lives.rectTransform.sizeDelta.x;
            m_Lives.rectTransform.sizeDelta = new Vector2(current - lives * 16, 16);
        }
        public void ChangeScore(int score)
        {
            m_Score.text = $"Score\n{score}";
        }
        public void ChangeHungry(int hungry)
        {
            m_Hungry.rectTransform.sizeDelta = new Vector2(hungry * 8, 16);
        }
        public void ChangeBest(int best)
        {
            m_Best.text = $"Best\n{best}";
        }

    }
}
