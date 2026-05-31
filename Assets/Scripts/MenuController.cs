using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
        playerMove.EnableLook();
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
