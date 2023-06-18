using System.Collections;
using UnityEngine;
using Glotonman2.Data;
namespace Glotonman2.Game
{
    public class Hungry : MonoBehaviour
    {
        [Tooltip("Hungry decrement by seconds")]
        public int m_Decrement = -10;
        public PlayerStats m_PlayerStats;
        void Start()
        {
            StartCoroutine(Decrement());
        }
        IEnumerator Decrement()
        {
            while (GameStatus.current.isPlaying)
            {
                yield return new WaitForSecondsRealtime(1);
                m_PlayerStats.UpdateHungry(m_Decrement);
            }
        }
    }
}
