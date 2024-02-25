using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    public float orbitalSpeed;

    void Update()
    {
        // Rotate the satellite around the origin (0, 0, 0) in a circular orbit (vertical movement)
        transform.RotateAround(Vector3.zero, Vector3.right, orbitalSpeed * Time.deltaTime);

        // Make the satellite face forward
        Vector3 forwardDirection = (transform.position - Vector3.zero).normalized;
        transform.rotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
    }
}
