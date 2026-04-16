using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseUI;
    public GameObject gameWinUI;

    public SpriteRenderer playerSprite;
    public PlayerMovement playerMovement;

    public static bool GameIsPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
            Debug.Log("Paused");
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }

    public void backtomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
