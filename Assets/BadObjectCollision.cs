using UnityEngine;
using System.Collections;

public class BadObjectCollision : MonoBehaviour
{
    public float scoreValue = 10f;
    public float healthValue = 10f;
    private Material originalMaterial;
    private Coroutine resetColorCoroutine;

    void Start()
    {
        // Store the original material to reset the color later
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spaceship"))
        {
            HandleNegativeCollision();

            // Assuming the SpaceshipController script is attached to the spaceship object or a relevant object
            SpaceshipController spaceshipScript = collision.gameObject.GetComponent<SpaceshipController>();
            if (spaceshipScript != null)
            {
                Moon moonScript = GetComponent<Moon>();
                if (moonScript != null)
                {
                    moonScript.MoonHit();
                }
                // Call Respawn when a negative collision occurs
                spaceshipScript.Respawn();
            }

        }
    }

    void HandleNegativeCollision()
    {
        // Visual effect for negative collision
        GetComponent<Renderer>().material.color = Color.red;

        // Decrement health
        HealthManager.Instance.DecreaseHealth((int)healthValue);

        // Decrement score
        ScoreManager.Instance.DecreaseScore((int)scoreValue); // Explicitly cast to int

        // Reset the color after 20 seconds
        if (resetColorCoroutine != null)
        {
            StopCoroutine(resetColorCoroutine);
        }
        resetColorCoroutine = StartCoroutine(ResetColorAfterDelay(20f));
    }

    IEnumerator ResetColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reset the color to the original state
        GetComponent<Renderer>().material = originalMaterial;
    }
}
