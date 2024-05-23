using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public RaycastHit GetColliderInfo()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(cameraRay, out RaycastHit hitInfo);

        return hitInfo;
    }
}
