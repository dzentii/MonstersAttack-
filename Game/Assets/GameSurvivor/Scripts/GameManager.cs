using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Enemy[] enemies;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private UIManager uiManager;

    [SerializeField] Camera mainCamera;

    private float gameTime;

    private void Update() 
    {
        gameTime += Time.deltaTime;
        uiManager.SetTimer(gameTime);
        
        if (player.IsDead)
        {
            mainCamera.transform.parent = null;
            foreach (var enemy in enemies)
                enemy.enabled = false;
            
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}