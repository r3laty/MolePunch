using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoleSpawner : MoleConfig
{
    [SerializeField] private MoleSpawnGrid spawnGrid;
    [Space]
    [SerializeField] private UiController UiController;
    [Space]
    public float gameDuration;

    private List<GameObject> _spawnedObjects = new List<GameObject>();
    [HideInInspector] public int _moleCount = 0;
    [HideInInspector] public bool isGameStarted;

    private void Start()
    {
        isGameStarted = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Get mouse button");
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
    public IEnumerator SpawnMolesWithDelay()
    {
        for (int x = 0; x < int.MaxValue; x++)
        {
            for (int z = 0; z < int.MaxValue; z++)
            {
                int randomX = Random.Range(0, spawnGrid.gridSize);
                int randomZ = Random.Range(0, spawnGrid.gridSize);


                Vector3 spawnPoint = transform.position + new Vector3(randomX * spawnGrid.cellSize, 0f, randomZ * spawnGrid.cellSize);
                int randomConfigIndex = Random.Range(0, molePrefab.Length);

                GameObject newMole = Instantiate(molePrefab[randomConfigIndex], spawnPoint, Quaternion.identity);

                _spawnedObjects.Add(newMole);

                if (_spawnedObjects.Count > 1)
                {
                    int randomIndex = Random.Range(0, _spawnedObjects.Count - 1);
                    GameObject objectToRemove = _spawnedObjects[randomIndex];
                    _spawnedObjects.RemoveAt(randomIndex);
                    Destroy(objectToRemove);
                }
                yield return new WaitForSeconds(spawnInterval[randomConfigIndex]);
            }
        }
    }

}