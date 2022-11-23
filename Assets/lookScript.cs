using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class lookScript : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;
    void Update()
    {
        if (Input.GetButton("lookDown"))
        {
            vCamera.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, -7, 0);
        }
        if (Input.GetButton("lookUp"))
        {
            vCamera.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 7, 0);
        }
        if (!Input.GetButton("lookDown") && !Input.GetButton("lookUp"))
        {
            vCamera.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 0, 0);
        }
    }
}
