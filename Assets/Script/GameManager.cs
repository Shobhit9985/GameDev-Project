using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float playerHealth = 100;
    float playerCollectedCoins = 0;
    public static GameManager instance;
    private GameState gameState;
    public ShopManagerScript manager;

    private void Start()
    {
        gameState = GameState.playing;
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public enum GameState
    {
        paused,
        playing,
        buyMenuPaused
    }

    public void StateUpdate(GameState state)
    {
        this.gameState = state;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void PlayerDamage(float damage)
    {
        playerHealth -= damage;
    }
}
