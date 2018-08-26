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
    public bool isShield = false;

    public float explosionForce = 1000f;

    //public AudioClip[] splosions;
    //public AudioSource splosionSource;

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
    /*
    private AudioClip GetRandomClip()
    {
        return splosions[Random.Range(0, 3)];
    }

    void PlayExplosion()
    {
        splosionSource.clip = GetRandomClip();
        splosionSource.Play();
    }
    */

    void Die()
    {
        if (aipath != null)
        {
            aipath.enabled = false;
        }
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce((Vector3.up * Random.value + Random.insideUnitSphere) * (Random.value + 0.2f) * explosionForce, ForceMode.Acceleration);
        rb.AddTorque(Random.insideUnitSphere * Random.value * 250000f);
        float destroyTimer = (Random.value * 0.5f) + 0.5f;
        if (isShield) destroyTimer = 0;
        Invoke("Explode", destroyTimer);
        //PlayExplosion();
        Destroy(gameObject, destroyTimer + 0.1f);
        Debug.Log("Sound");
    }

    void Explode()
    {
        if (deathEffects.Length == 0)
            return;
        int choose = Random.Range(0, deathEffects.Length);
        GameObject deathGO = Instantiate(deathEffects[choose], transform.position, Random.rotationUniform);
        deathGO.transform.localScale *= ExplosionScale;
        Debug.Log("Did explosion index: " + choose);
    }
}

