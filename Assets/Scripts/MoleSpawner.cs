using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private MoleSpawnGrid spawnGrid;
    [SerializeField] private GameObject molePrefab;
    [SerializeField] private float spawnInterval = 2.0f;
    private List<GameObject> _spawnedObjects = new List<GameObject>();
    private void Start()
    {
        StartCoroutine(SpawnMolesWithDelay());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (_spawnedObjects.Contains(clickedObject))
                {
                    DeathEffect deathEffectController = clickedObject.GetComponent<DeathEffect>();
                    if (deathEffectController != null)
                    {
                        deathEffectController.PlayDeathEffect();
                    }
                    _spawnedObjects.Remove(clickedObject);
                    Destroy(clickedObject);
                }
            }
        }
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
}