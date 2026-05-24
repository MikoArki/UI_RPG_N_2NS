using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagere : MonoBehaviour
{
    public Character selectedChar;

    public Player player;

    public Enemy currentEnemy;
    [SerializeField] private TMP_Text playerName, playerHP, enemyName, enemyHP,
    gameOverText;
    [SerializeField] private Image enemyPreview;
    [SerializeField] private Enemy[] allEnemies;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject gameCanvas;
    
    [Header("Audio")]
    public AudioSource musicSource;
    public AudioClip backgroundMusic;
    public void Start()
    {
        gameOverText.enabled = false;
        restartButton.enabled = false;
        SetCurrentEnemy();
        RefreshUI();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void Fight()
    {
        player.Attack(currentEnemy);
        if (currentEnemy.Health <= 0)
        {
            SetCurrentEnemy();
        }
        else
        {
            currentEnemy.Attack(player);
        }
        //currentEnemy.Attack(player);
        RefreshUI();
    }

    public void HeallingButton()
    {
        player.Heal(player);
        RefreshUI();
    }
    
    private void SetCurrentEnemy()
    {
        int enemyIndex = Random.Range(0, allEnemies.Length);
        currentEnemy = allEnemies[enemyIndex];
        currentEnemy.Reset();
    }

    public void RefreshUI()
    {
        playerName.text = player.CharName;
        playerHP.text = "HP:" + player.Health.ToString("F1");
        
        enemyName.text = currentEnemy.CharName;
        enemyHP.text = "HP:" + currentEnemy.Health.ToString("F1");
        enemyPreview.sprite = currentEnemy.enemyImage;
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        restartButton.enabled = true;
        gameCanvas.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        if (player.Health  <= 0)
        {
           GameOver();
           musicSource.Stop();
        }
    }
}
