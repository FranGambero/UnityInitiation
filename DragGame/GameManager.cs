using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool _paused;
    private int level;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("Level");
    }
    private void Start()
    {
        SetPauseGame(false);
    }


    public void SetPauseGame(bool pause)
    {
        _paused = pause;
        Time.timeScale = pause ? 0 : 1;
        pausePanel.SetActive(pause);
    }

    public void enemyDies()
    {
        pausePanel.SetActive(true);
    }

    private void checkEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("GANAS");
            level++;
            PlayerPrefs.SetInt("Level", level);
            SceneManager.LoadScene(level);

        }
    }

    public void reStart()
    {
        //int level = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPauseGame(!_paused);
        this.checkEnemies();    
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void startGame()
    {
        SceneManager.LoadScene(2);
    }

    public void goToSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
