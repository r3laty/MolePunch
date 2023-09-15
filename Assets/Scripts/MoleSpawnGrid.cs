using UnityEngine;

public class MoleSpawnGrid : MonoBehaviour
{
    public int gridSize = 3;
    public int cellSize = 1;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 spawnPoint = transform.position + new Vector3(x * cellSize, 0f, z * cellSize);
                Gizmos.DrawWireCube(spawnPoint, Vector3.one * cellSize);
            }
        }
    }
}
