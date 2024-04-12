using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("Cutscene");       //if i have time i will add a cutscene
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quitting...");
        Application.Quit();
    }
}
