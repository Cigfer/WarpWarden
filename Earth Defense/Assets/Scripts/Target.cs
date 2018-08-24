using Pathfinding;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum Mode { SIMPLE, SNAKE }

    public float health = 20f;

    public AIPath aipath;

    public GameObject[] protectors;

    public GameObject[] deathEffects;

    public Mode HealthMode = Mode.SIMPLE;

    private bool snakedead = false;

    public float ExplosionScale = 1.0f;

    public void TakeDamage(float amount)
    {
        if (HealthMode == Mode.SIMPLE)
        {
            if (!HasProtection())
            {
                health -= amount;
                if (health <= 0f)
                {
                    Die();
                }
            }
        }
        else
        {
            health -= amount;
            if (health <= 0f)
            {
                SnakeBodyDie();
            }
        }
    }

    bool HasProtection()
    {
        for (int i = 0; i < protectors.Length; i++)
        {
            if (protectors[i] != null)
            {
                return true;
            }
        }
        return false;
    }

    void SnakeBodyDie()
    {
        if (!snakedead)
        {
            Invoke("Explode", 0);
            HideSelf();
            snakedead = true;
        }
    }

    void HideSelf()
    {
        Destroy(transform.GetChild(0).gameObject);
    }

    void Die()
    {
        aipath.enabled = false;
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce((Vector3.up * Random.value + Random.insideUnitSphere) * (Random.value + 0.2f) * 1000f, ForceMode.Acceleration);
        rb.AddTorque(Random.insideUnitSphere * Random.value * 250000f);
        float destroyTimer = (Random.value * 0.5f) + 0.5f;
        Invoke("Explode", destroyTimer);
        Destroy(gameObject, destroyTimer + 0.1f);
    }

    void Explode()
    {
        int choose = Random.Range(0, deathEffects.Length);
        GameObject deathGO = Instantiate(deathEffects[choose], transform.position, Random.rotationUniform);
        deathGO.transform.localScale *= ExplosionScale;
        Debug.Log("Did explosion index: " + choose);
        while (Random.value > 0.5f)
        {
            choose = Random.Range(0, deathEffects.Length);
            GameObject deathGO2 = Instantiate(deathEffects[choose], transform.position, Random.rotationUniform);
        }
    }
}

