using System.Collections;
using TMPro;
using UnityEngine;

namespace Glotonman2.Animations
{

    public class TextTitleFall : MonoBehaviour
    {
        public float m_VerticalDistance = 1f;
        public float m_Duration = 2f;
        private Vector3 startPosition;

        private void Start()
        {
            startPosition = transform.position;
            StartCoroutine(MoveUpDown());
        }

        private IEnumerator MoveUpDown()
        {
            while (true)
            {
                yield return StartCoroutine(MoveTo(startPosition + Vector3.up * m_VerticalDistance));
                yield return StartCoroutine(MoveTo(startPosition));
            }
        }

        private IEnumerator MoveTo(Vector3 targetPosition)
        {
            float timer = 0f;
            Vector3 startPosition = transform.position;

            while (timer < m_Duration)
            {
                float t = timer / m_Duration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                timer += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}