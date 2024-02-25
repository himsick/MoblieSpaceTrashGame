using UnityEngine;

public class SatelliteOrbit : MonoBehaviour
{
    public float orbitalSpeed;

    void Update()
    {
        // Rotate the satellite around the origin (0, 0, 0) in a circular orbit
        transform.RotateAround(Vector3.zero, Vector3.up, -orbitalSpeed * Time.deltaTime);

        // Make the satellite face forward
        Vector3 forwardDirection = (transform.position - Vector3.zero).normalized;
        transform.rotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
    }
}