using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private MoleSpawnGrid spawnGrid;

    private void Start()
    {
        CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (virtualCamera != null && spawnGrid != null)
        {
            float gridSize = spawnGrid.gridSize;
            float cellSize = 1.0f;
            float cameraSize = gridSize * cellSize * 0.5f;
            virtualCamera.m_Lens.OrthographicSize = cameraSize;
        }
    }
}
