using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpinner : MonoBehaviour
{
    public Transform parent;
    public float SpinRate = 1f;

    // Update is called once per frame
    void Update()
    {
        if (parent != null)
        {
            this.transform.position = parent.transform.position;
            this.transform.Rotate(Vector3.up, SpinRate * Time.deltaTime);
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var ch = transform.GetChild(i);
                var rb = ch.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(rb.transform.localPosition.normalized * (Random.value + 0.2f) * 1000f, ForceMode.Acceleration);
                rb.AddTorque(Random.insideUnitSphere * Random.value * 250000f);
                Destroy(ch.gameObject, 5f);
            }
            transform.DetachChildren();
            Destroy(transform.parent.gameObject, 5f);
        }
    }
}
