using UnityEngine;

public class SpaceTrash : MonoBehaviour
{
    public int scoreValue = 10;
    public GameObject spaceTrashPrefab; // Reference to your prefab

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spaceship"))
        {
            Collect();
        }
        else if (collision.gameObject.CompareTag("Planet") || collision.gameObject.CompareTag("Moon") || collision.gameObject.CompareTag("Satellite"))
        {
            // Decrease health, decrement score, spawn space trash near impact point, etc.
            HandleNegativeCollision();
        }
    }

void Collect()
{
    // Visual change (e.g., change color)
    GetComponent<Renderer>().material.color = Color.green;

    // Increment score
    ScoreManager.Instance.IncreaseScore(scoreValue);

    // Destroy the space trash once it is out of the camera view
    Destroy(gameObject, 1f);


}


    void HandleNegativeCollision()
    {
        // Visual effect for negative collision
        GetComponent<Renderer>().material.color = Color.red;

        // Decrement health
        HealthManager.Instance.DecreaseHealth(20);

        // Decrement score
        ScoreManager.Instance.DecreaseScore(20);

        // Spawn space trash near the point of impact
        SpawnSpaceTrashNearImpactPoint();

        // Destroy the space trash once it is out of the camera view
        Destroy(gameObject, 1f);
    }

    void SpawnSpaceTrashNearImpactPoint()
    {
        if (spaceTrashPrefab != null)
        {
            // Instantiate the specified space trash prefab near the point of impact
            Debug.Log("Spawning space trash...");
            Vector3 spawnPosition = transform.position + (Random.onUnitSphere * 10f);
            Instantiate(spaceTrashPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Space trash prefab not assigned in the inspector.");
        }
    }
}
