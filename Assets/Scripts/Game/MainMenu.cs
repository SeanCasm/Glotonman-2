using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Glotonman2.Game
{
    public class MainMenu : MonoBehaviour
    {
        public void ChangeToGameplayScene()
        {
            SceneManager.LoadScene(1);
            GameStatus.current.globalStatus = GlobalStatus.WaitingKey;
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}
