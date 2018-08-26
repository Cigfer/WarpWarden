using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon_Pistol : MonoBehaviour {

    public WarpManager warpManager;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;


    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public Animator animator;

    private float nextTimeToFire = 0f;

    public PullUpMap mapIsUp;

    public WepSwitch recoilMotor;

    public LayerMask HitscanLayerMask;
    
    public float recoilIntensity = 1f;

    public GameObject uiAmmo;

    //public AudioSource shootSource;
    //public AudioClip shootClip;

    public GameObject teleIndicator;

    [HideInInspector]
    public LayerMask manualTeleportCubby;
    public LayerMask manualTeleportCubby1;
    public LayerMask manualTeleportCubby2;
    public LayerMask manualTeleportCubby3;
    public LayerMask manualTeleportCubby4;
    public LayerMask manualTeleportCubby5;
    public LayerMask manualTeleportCubby6;
    public LayerMask manualTeleportCubby7;
    public LayerMask manualTeleportCubby8;
    public LayerMask manualTeleportCubby9;
    public LayerMask manualTeleportCubby10;
    public LayerMask manualTeleportCubby11;

    void Start()
    {
        //shootSource.clip = shootClip;

        currentAmmo = maxAmmo;

        if (mapIsUp == null)
        {
            mapIsUp = GameObject.Find("Canvas").GetComponent<PullUpMap>();
        }   

        //teleIndicator.SetActive(true);
    }

    void OnEnable()
    {
        uiAmmo.SetActive(true);
        //isReloading = false;
        //animator.SetBool("Reloading", false);
    }

    void OnDisable()
    {
        uiAmmo.SetActive(false);
    }

    public bool IsReloading()
    {
        return isReloading;
    }

    void teleportationIndicator()
    {
        
    }

    void Update()
    {
        if (isReloading)
            return;

        //currentAmmo <= 0 | Auto reload on empty

        if (Input.GetKey("r"))
        {
            StartCoroutine("Reload");
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0 && mapIsUp.bigmap.active == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            Shoot();
        }   

        RaycastHit loc;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    warpManager.player.transform.position = warpManager.tpLocations[0].transform.position;
                    warpManager.player.transform.rotation = warpManager.tpLocations[0].transform.rotation;
                }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby1))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[1].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[1].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby2))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[2].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[2].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby3))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[3].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[3].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby4))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[4].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[4].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby5))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[5].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[5].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby6))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[6].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[6].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby7))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[7].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[7].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby8))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[8].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[8].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby9))
        {
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[9].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[9].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby10))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[10].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[10].transform.rotation;
            }
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out loc, range, manualTeleportCubby11))
        {

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                warpManager.player.transform.position = warpManager.tpLocations[11].transform.position;
                warpManager.player.transform.rotation = warpManager.tpLocations[11].transform.rotation;
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

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

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, HitscanLayerMask))
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

        recoilMotor.Shake(recoilIntensity);

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
