using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalScript1 : MonoBehaviour
{
    public livesScript lives;

    public int SmallBoyDamage;
    public int SnakeBoyDamage;
    public int BigBoyDamage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SmallBoy")
        {
            lives.damage -= SmallBoyDamage;
        }

        if (other.gameObject.tag == "SnakeBoy")
        {
            lives.damage -= SnakeBoyDamage;
        }

        if (other.gameObject.tag == "BigBoy")
        {
            lives.damage -= BigBoyDamage;
        }

        Destroy(other.gameObject);
    }
}
