using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");

        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
        playerMove.EnableLook();
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        HideMouse();

        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
        playerMove.EnableLook();
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
