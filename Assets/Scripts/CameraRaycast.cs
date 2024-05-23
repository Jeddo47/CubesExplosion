using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public void FireRaycast(out RaycastHit hitInfo)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(cameraRay, out hitInfo);
    }
}
