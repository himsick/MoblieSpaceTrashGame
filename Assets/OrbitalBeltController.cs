using UnityEngine;


namespace MyNamespace
{
    public class OrbitalBeltController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Rotation speed of the orbital belt
    public Vector3 pivotOffset(){
            return transform.GetComponent<Renderer>().bounds.center;
    }
    void Update()
    {
        // Set the pivot point to the center of the object

        // Rotate the orbital belt around its own axis
        transform.RotateAround(pivotOffset(), Vector3.up, rotationSpeed * Time.deltaTime);
    }
    
}
}