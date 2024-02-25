using UnityEngine;

public class SpacecraftLights : MonoBehaviour
{
    // Public variables that you can set in the Unity Editor
    public Light directionalLight; // Reference to a directional light (presumably for overall scene lighting)
    public Light spotLight; // Reference to the spotlight you want to rotate
    public float rotationAngle = 30f; // The maximum angle by which the spotlight will rotate
    public float rotationSpeed = 2f; // The speed at which the spotlight will rotate

    void Update()
    {
        // Rotate the Spot Light cyclically based on a sine function
        float angle = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;

        // Set the local rotation of the spotlight around the Y-axis
        spotLight.transform.localRotation = Quaternion.Euler(0, angle, 0);
    }
}
