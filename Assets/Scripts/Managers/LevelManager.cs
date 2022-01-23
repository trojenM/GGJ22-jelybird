using System.Collections;
using System.Collections.Generic;
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

    private AudioSource audioSource;
    [SerializeField] private AudioClip hitSfx;

    private Animator MenuAnimator;

    [SerializeField] private EnemySpawner enemySpawnerLeft, enemySpawnerRight;
    
    private void Awake()
    {
        MainMenuScr.SetActive(true);
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        MenuAnimator = MainMenuScr.GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void GetDamage(int damageAmount)
    {
        health -= damageAmount;
        audioSource.PlayOneShot(hitSfx, 2f);

        if (health > 0)
        {
            HealthBarImg.fillAmount -= 0.2f;
        }

        CheckGameIsOver();
    }

    private void CheckGameIsOver()
    {
        if (health <= 1)
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
        enemySpawnerLeft.enabled = true;
        enemySpawnerRight.enabled = true;
        MainMenuScr.SetActive(true);
        InGameScr.SetActive(true);
        MenuAnimator.SetTrigger("transitionToGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        MenuAnimator.SetTrigger("transitionToCredits");
    }

    public void goBackToMenu()
    {
        MenuAnimator.SetTrigger("transitionToMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
