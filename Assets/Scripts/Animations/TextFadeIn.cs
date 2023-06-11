using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Glotonman2.Animations
{

    public class TextFadeIn : MonoBehaviour
    {
        public float m_CharDelay = 0.1f;
        private TMP_Text textComponent;
        // Start is called before the first frame update
        void Start()
        {
            textComponent = GetComponent<TMP_Text>();
            textComponent.alpha = 0f;
            StartCoroutine(FadeInText());
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
        }
    }
}
