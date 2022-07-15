using UnityEngine;
using UnityEngine.SceneManagement;

namespace PTWO_PR
{
    public class MenuManager : MonoBehaviour
    {
        private void Update()
        {
            // back to main menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }

        }

        
        // Scene loading methods for the buttons
        public void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        public void GoToOptions()
        {
            SceneManager.LoadScene("Options");
        }

        public void GoToControls()
        {
            SceneManager.LoadScene("Controls");
        }

        public void GoToCredits()
        {
            SceneManager.LoadScene("Credits");
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Game has been quit");
        }
    }
}
