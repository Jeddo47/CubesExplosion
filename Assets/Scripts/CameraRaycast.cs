using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out CubeStats cubeStats)) 
                {
                    _spawner.MultiplyCubes(hitInfo, cubeStats);                    
                }
            }
        }
    }
}
