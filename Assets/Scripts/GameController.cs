using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
   public enum GameStay
    {
        Defauld,
        Game,
        Win,
        Lose,
        Stop
    }

    public GameStay StayGame = GameStay.Defauld;

    private void Start()
    {
        Application.targetFrameRate = 60;
       // PlayerPrefs.SetInt(Constants.Tutorial, 3);
    }
}
