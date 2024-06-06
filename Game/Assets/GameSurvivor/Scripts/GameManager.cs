using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Enemy[] enemies;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private UIManager uiManager;

    private float gameTime;

    private void Update() 
    {
        gameTime += Time.deltaTime;
        uiManager.SetTimer(gameTime);
        
        if (player.IsDead)
        {
            foreach (var enemy in enemies)
                enemy.enabled = false;

            gameOverPanel.SetActive(true);
        }
    }
}