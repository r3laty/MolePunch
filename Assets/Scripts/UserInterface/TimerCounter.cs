using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TimerCounter : MonoBehaviour
{
    [SerializeField] private List<MoleSpawner> spawner;
    [SerializeField] private UiController ui;
    [Space]
    [SerializeField] private TextMeshProUGUI timerText;
  
    private float _currentTime = 0;
    private string _textTemplate;

    private Dictionary<string, int> _lvlMode = new Dictionary<string, int>();
    private void Start()
    {
        
    }
    private void Update()
    {
        if(!ui.gamemodChosen) _textTemplate = "Easy mode, time left " + _currentTime.ToString("F0");

        if (ui.easy)
        {
            _textTemplate = "Easy mode, time left " + _currentTime.ToString("F0");
            _lvlMode.Add("EasyMode", 0);
            StartCoroutine(StartGame(_lvlMode["EasyMode"]));
        } 
        if(ui.normal)
        {
            _textTemplate = "Normal mode, time left " + _currentTime.ToString("F0");
           _lvlMode.Add("NormalMode", 1);
            StartCoroutine(StartGame(_lvlMode["NormalMode"]));
        } 
        if(ui.hard)
        {
            _textTemplate = "Hard mode, time left " + _currentTime.ToString("F0");
            _lvlMode.Add("HardMode", 2);
            StartCoroutine(StartGame(_lvlMode["HardMode"]));
        }
    }
    private IEnumerator StartGame(int currentGameMode)
    {
        Debug.Log("Coroutine");
        _currentTime = spawner[currentGameMode].gameDuration;
        StartCoroutine(spawner[currentGameMode].SpawnMolesWithDelay());

        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerText(timerText, _textTemplate);
            yield return null;
        }

        Debug.Log("Game ended!");
    }
    private void UpdateTimerText(TextMeshProUGUI tmpText, string textTemplate)
    {
        if (ui.easy || ui.normal || ui.hard || !ui.gamemodChosen)
        {
            tmpText.text = _textTemplate;
        }
    }
}
