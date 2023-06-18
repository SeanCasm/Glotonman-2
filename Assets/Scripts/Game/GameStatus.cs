using UnityEngine;
namespace Glotonman2.Game
{
    public class GameStatus : MonoBehaviour
    {
        public static GameStatus current;
        public GlobalStatus globalStatus { get; set; } = GlobalStatus.MainScreen;

        public bool isPlaying => GlobalStatus.Playing == globalStatus;
        private void Start()
        {
            if (!current)
            {
                current = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
    public enum GlobalStatus
    {
        MainScreen, WaitingKey, Playing, Death
    }
}
