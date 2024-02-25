using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera topDownCamera;
    public Button switchButton; // Reference to the UI button

    private bool isSwitching = false;

    void Start()
    {
        // Ensure only the first-person camera is initially active
        EnableCamera(firstPersonCamera);
        DisableCamera(topDownCamera);

        // Add a listener to the UI button for camera switching
        switchButton.onClick.AddListener(ToggleCameras);
    }

    void Update()
    {
        // Switch cameras only when holding the "C" key
        if (Input.GetKey(KeyCode.C))
        {
            if (!isSwitching)
            {
                isSwitching = true;
                ToggleCameras();
            }
        }
        else
        {
            isSwitching = false;
        }
    }

    void ToggleCameras()
    {
        // Check which camera is currently active and switch to the other one
        if (firstPersonCamera.gameObject.activeSelf)
        {
            EnableCamera(topDownCamera);
            DisableCamera(firstPersonCamera);
        }
        else
        {
            EnableCamera(firstPersonCamera);
            DisableCamera(topDownCamera);
        }
    }

    void EnableCamera(CinemachineVirtualCamera camera)
    {
        camera.gameObject.SetActive(true);
    }

    void DisableCamera(CinemachineVirtualCamera camera)
    {
        camera.gameObject.SetActive(false);
    }
}
