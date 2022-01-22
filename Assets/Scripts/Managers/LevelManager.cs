using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private int health = 6; // 6 half heart

    [SerializeField] private GameObject MainMenuScr;

    [HideInInspector] public bool isGameEnded = false;
    
    private void Awake()
    {
        MainMenuScr.SetActive(true);
        Time.timeScale = 0;
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damageAmount)
    {
        health -= damageAmount;
        CheckGameIsOver();
        Debug.Log(health);
    }

    private void CheckGameIsOver()
    {
        if (health <= 0)
        {
            GameOver();    
        }
    }

    private void GameOver()
    {
        // game over state        
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        MainMenuScr.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
