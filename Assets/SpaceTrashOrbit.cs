using UnityEngine;

public class SpaceTrashOrbit : MonoBehaviour
{
    public Transform moon;
    public float orbitRadius = 5f;
    public float orbitSpeed = 2f;

    void Update()
    {
        OrbitAroundMoon();
    }

    void OrbitAroundMoon()
    {
        // Calculate the position in a circular orbit
        float angle = Time.time * orbitSpeed;
        float x = Mathf.Cos(angle) * orbitRadius;
        float z = Mathf.Sin(angle) * orbitRadius;

        // Set the position of the space trash relative to the moon
        transform.position = moon.position + new Vector3(x, 0, z);
    }
}
