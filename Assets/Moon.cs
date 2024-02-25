using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject spaceTrashPrefab1;
    public GameObject spaceTrashPrefab2;
    public Transform trashSpawnPoint;
    public float spawnInterval = 20f;

    private float timer = 0f;
    private bool spawnPrefab1 = true;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnSpaceTrash();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnSpaceTrash()
    {
        // Determine which prefab to spawn
        GameObject prefabToSpawn = spawnPrefab1 ? spaceTrashPrefab1 : spaceTrashPrefab2;

        // Instantiate the selected space trash prefab at the spawn point
        Instantiate(prefabToSpawn, trashSpawnPoint.position, Quaternion.identity);

        // Switch to the other prefab for the next spawn
        spawnPrefab1 = !spawnPrefab1;
    }

    // Call this method when the moon gets hit
    public void MoonHit()
    {
        // Spawn a new space trash when the moon gets hit
        SpawnSpaceTrash();
    }
}
