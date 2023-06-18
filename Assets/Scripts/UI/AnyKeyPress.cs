using UnityEngine;
using UnityEngine.Events;
using Glotonman2.Game;

namespace Glotonman2.InputKey
{
    public class AnyKeyPress : MonoBehaviour
    {
        public UnityEvent m_PressActions;
        private void Start()
        {
            GameStatus.current.globalStatus = GlobalStatus.WaitingKey;
        }
        private void Update()
        {
            if (Input.anyKeyDown)
                KeyPressed();
        }
        public void KeyPressed()
        {
            m_PressActions?.Invoke();
            GameStatus.current.globalStatus = GlobalStatus.Playing;
        }
    }
}
