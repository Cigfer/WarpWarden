using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 20f;

    public GameObject deathEffect;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

        GameObject deathGO = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathGO, 3f);

        //ScoreScript.scoreValue -= 1;
    }
}

