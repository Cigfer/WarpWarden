using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nudger : MonoBehaviour
{

    private Rigidbody rb;

    public float TimeBetweenPushes = 5f;

    public float ForceMultiplier = 5f;
    private float LastTimePushed = 0f;

    private float intensity = 0;

    private float targetY;

    public float springConstant = 500;
    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
        targetY = transform.position.y + 4 * (Random.value - 0.5f);
    }
	
	// Update is called once per frame
    void Update()
    {
        Nudge();
        if (TimeBetweenPushes + LastTimePushed < Time.time)
        {
            NudgeRandomize();
            LastTimePushed = Time.time;
        }
        float restoringForce = (targetY - transform.position.y) * Time.deltaTime * springConstant;
        rb.AddForce(Vector3.up * restoringForce, ForceMode.Acceleration);
        Debug.DrawLine(transform.position, transform.position + Vector3.up * (targetY - transform.position.y), Color.red);
    }

    void NudgeRandomize()
    {
        intensity = Random.value - 0.5f;
    }

    void Nudge()
    {
        rb.AddForce(transform.right * intensity * ForceMultiplier * Time.deltaTime);
        Debug.DrawLine(transform.position, transform.position + transform.forward * 2, Color.red);
        Debug.DrawLine(transform.position, transform.position + transform.right * 4 * intensity, Color.red);
    }
}
