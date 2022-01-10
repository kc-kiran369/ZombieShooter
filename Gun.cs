using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] Camera camera;
    [Header("Informations")]
    [SerializeField] float shootingRange = 100f;
    [SerializeField] byte fireRate = 7;
    float nextTimeToFire = 0f;
    [Header("Effects")]
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystemStorage ps;
    [Header("Audios")]
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
        Ammo.Fire();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, shootingRange))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                KillEnemy();
                Instantiate(ps.ReturnBloodEffect(), hit.point, Quaternion.LookRotation(hit.normal));
            }else if(hit.transform.gameObject.CompareTag("Explosive"))
            {
                hit.transform.gameObject.GetComponent<Explosive>().Explode();
            }
            else
            {
                Instantiate(ps.ReturnSandEffect(), hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }


    void KillEnemy()
    {
        //Debug.Log("pew pew");
    }
}