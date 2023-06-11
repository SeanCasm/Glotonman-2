using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Glotonman2.Animations
{
    public class RectMoveVertical : MonoBehaviour
    {
        public float m_Time = 1f;
        public float m_Delay = 2f;
        public float m_TargetY;
        public UnityEvent m_Completed;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Translate());
        }

        private IEnumerator Translate()
        {
            yield return new WaitForSeconds(m_Delay);
            float timer = 0;
            while (timer < m_Time)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, m_TargetY), m_Time * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;

            }
            m_Completed?.Invoke();
        }
    }
}
