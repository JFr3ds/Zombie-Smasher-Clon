using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState actualGameState;

    private void Start()
    {
        OnLaunchGame(actualGameState);
    }

    void OnLaunchGame(GameState gs)
    {
        switch (gs)
        {
            case GameState.MainMenu:

                break;
            case GameState.Play:
                //WaveController.Instance.
                break;
            case GameState.GameOver:

                break;
        }
    }

}
public enum GameState
{ 
    MainMenu,
    Play,
    GameOver
}
