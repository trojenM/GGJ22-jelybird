using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private int health = 6; // 6 half heart

    [SerializeField] private Image HealthBarImg;
    
    [SerializeField] private GameObject MainMenuScr, InGameScr;

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

        if (health > 0)
        {
            HealthBarImg.fillAmount -= 0.2f;
        }

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
        RestartGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        MainMenuScr.SetActive(false);
        InGameScr.SetActive(true);
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
