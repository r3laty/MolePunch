using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [Header("Freezing time")]
    [SerializeField] private GameObject spawning;
    [Space]
    [HideInInspector] public bool easy, normal, hard, gameStarted, gamemodChosen;

    public void OnStartClick()
    {
        if (easy || normal || hard)
        {
            gameStarted = false;
        }
        else
        {
            Debug.Log("Game started without choosing gamemod");
            gameStarted = true;
        }

        Debug.Log("Game just started!");
    }
    public void GamemodEasy()
    {
        easy = true;
        gamemodChosen = true;
        Debug.Log("Easy");
    }
    public void GamemodNormal()
    {
        normal = true;
        gamemodChosen = true;
        Debug.Log("Medium");
    }

    public void GamemodHard()
    {
        hard = true;
        gamemodChosen = true;
        Debug.Log("Hard"); 
    }
}
