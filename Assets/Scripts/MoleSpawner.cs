using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private MoleSpawnGrid spawnGrid;
    [Space]
    [SerializeField] private UiController UiController;
    [Space]
    [SerializeField] private GameObject molePrefab;
    [Space]
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private float gameDuration = 60.0f;
    [Space]
    [SerializeField] private TextMeshProUGUI timerText; 
    private float _currentTime = 0;

    private List<GameObject> _spawnedObjects = new List<GameObject>();
    [HideInInspector] public int _moleCount = 0;

    private void Start()
    {
        if (UiController.gameStarted || UiController.gamemodChosen)
        {
            StartCoroutine(StartGame());
        }
    }

    private void Update()
    {
        Debug.Log(Time.timeScale + " time scale");
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                if (clickedObject.CompareTag("Finish"))
                {
                    _moleCount++;
                    _spawnedObjects.Remove(clickedObject);
                    Destroy(clickedObject);
                }
            }
        }
    }
    private IEnumerator StartGame()
    {
        _currentTime = gameDuration;
        StartCoroutine(SpawnMolesWithDelay());

        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerText(timerText);
            yield return null;
        }

        // Время истекло, завершаем игру
        Debug.Log("Game ended!");
    }

    private IEnumerator SpawnMolesWithDelay()
    {
        for (int x = 0; x < int.MaxValue; x++)
        {
            for (int z = 0; z < int.MaxValue; z++)
            {
                int randomX = Random.Range(0, spawnGrid.gridSize);
                int randomZ = Random.Range(0, spawnGrid.gridSize);


                Vector3 spawnPoint = transform.position + new Vector3(randomX * spawnGrid.cellSize, 0f, randomZ * spawnGrid.cellSize);
                GameObject newMole = Instantiate(molePrefab, spawnPoint, Quaternion.identity);
                _spawnedObjects.Add(newMole);

                if (_spawnedObjects.Count > 2)
                {
                    int randomIndex = Random.Range(0, _spawnedObjects.Count - 1);
                    GameObject objectToRemove = _spawnedObjects[randomIndex];
                    _spawnedObjects.RemoveAt(randomIndex);
                    Destroy(objectToRemove);
                }
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
    private void UpdateTimerText(TextMeshProUGUI tmpText)
    {
        if (UiController.easy || UiController.gameStarted)
        {
            tmpText.text = "Easy mode, time left " + _currentTime.ToString("F0");
        }
    }
}