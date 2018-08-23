using UnityEngine;
using System.Collections;

public class Weapon_Pistol : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public Animator animator;

    private float nextTimeToFire = 0f;

    public WepSwitch recoilMotor;

    /*
    private Vector3 originalPosition;
    public Vector3 aimPosition;
    public float adsSpeed = 8f;
    */

    //public AudioSource shootSource;
    //public AudioClip shootClip;

    // Update is called once per frame

    void Start()
    {
        //shootSource.clip = shootClip;

        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        //currentAmmo <= 0 | Auto reload on empty

        if (Input.GetKey("r"))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        animator.SetBool("Reloading", true);

        //extra time with reloadTime is because guns fire before animation is fully complete

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        //shootSource.Play();

        currentAmmo--;
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.1f);

        }

        recoilMotor.recoil();

    }

    /*private void AimDownSights()
        {
            if (Input.GetButton("Fire2") && !isReloading)
            {
                Debug.Log("AIMING");
                transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * adsSpeed);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * adsSpeed);
            }
        }*/

    /*void SecFire()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

        //Destroy(Temporary_Bullet_Handler, 5f);
    }*/
}
