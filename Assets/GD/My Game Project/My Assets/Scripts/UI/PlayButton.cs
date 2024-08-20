using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts.UI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private Button playButton;
    
        public void OnPlayButtonClicked()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
