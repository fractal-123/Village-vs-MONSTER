using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public void RestartLvl()
    {
        SceneManager.LoadScene("LVL_1");
        Time.timeScale = 1;
    }


    public void PauseClick()
    {
        Time.timeScale = 0;
    }
    
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void OnPause()
    {
        Time.timeScale = 1;
    }
}
