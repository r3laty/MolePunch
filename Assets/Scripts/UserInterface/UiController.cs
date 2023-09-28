using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [HideInInspector] public bool easy, normal, hard, gamemodChosen;

    public void OnStartClick()
    {
        if (!easy || !normal || !hard)
        {
            gamemodChosen = false;
        }
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
    public void Pause() => Time.timeScale = 0;
    public void Continue() => Time.timeScale = 1;
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
