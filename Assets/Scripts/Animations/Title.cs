using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Glotonman2.Animations
{

    public class Title : MonoBehaviour
    {
        public float m_CharDelay = 0.1f;
        public UnityEvent m_FadeCompleted;
        public UnityEvent m_MoveUpCompleted;
        private TMP_Text textComponent;
        void Start()
        {
            textComponent = GetComponent<TMP_Text>();
            textComponent.alpha = 0f;
            StartCoroutine(FadeInText());
        }
        private void OnMoveUpCompleted()
        {
            m_MoveUpCompleted?.Invoke();
        }
        private IEnumerator FadeInText()
        {
            int totalChars = textComponent.text.Length;

            for (int i = 0; i < totalChars; i++)
            {
                textComponent.maxVisibleCharacters = i + 1;
                textComponent.alpha = Mathf.Lerp(0f, 1f, (float)i / totalChars);
                yield return new WaitForSeconds(m_CharDelay);
            }

            textComponent.maxVisibleCharacters = totalChars;
            textComponent.alpha = 1f;
            m_FadeCompleted?.Invoke();
        }
    }
}
