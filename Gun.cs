using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float shootingRange = 100f;
    [SerializeField] byte fireRate = 7;
    float nextTimeToFire = 0f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFX;
    [SerializeField] AudioSource gunFX;
    private void Awake()
    {
        camera = Camera.main;
        gunFX = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GameState.currentGameState == GameState.CurrentGameState.Playing)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        gunFX.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, shootingRange))
        {
            GameObject fx = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(fx, 0.5f);
        }
        if (hit.transform.gameObject.CompareTag("Enemy"))
        {
            hit.transform.gameObject.SetActive(false);
        }
    }
}