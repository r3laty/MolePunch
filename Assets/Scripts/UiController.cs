using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [HideInInspector] public bool easy = false, normal = false, hard = false, gamemodChosen = false;
    public void OnStartClick()
    {
        if (!easy || !normal || !hard)
        {
            Debug.Log("Game started without choosing gamemod");
            gamemodChosen = false;
        }


        Debug.Log("Game just started!");
    }
    public void GamemodeEasy()
    {
        easy = true;
        gamemodChosen = true;
        Debug.Log("Easy");
    }
    public void GamemodeNormal()
    {
        normal = true;
        gamemodChosen = true;
        Debug.Log("Medium");
    }

    public void GamemodeHard()
    {
        hard = true;
        gamemodChosen = true;
        Debug.Log("Hard"); 
    }
}
