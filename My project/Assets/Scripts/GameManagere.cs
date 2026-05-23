using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.UI;
public class GameManagere : MonoBehaviour
{
    public Character selectedChar;

    public Player player;

    public Enemy currentEnemy;
    [SerializeField] private TMP_Text playerName, playerHP, enemyName, enemyHP;
    [SerializeField] private Image enemyPreview;
    [SerializeField] private Enemy[] allEnemies;

    public void Start()
    {
        SetCurrentEnemy();
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
    
    void Update()
    {
        
    }
}
