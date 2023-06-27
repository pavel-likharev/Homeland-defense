using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnPos;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI = false;
    [SerializeField] float minimumFireRate = 0.2f;
    [SerializeField] float fireTimeVarience = 0;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
           
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContiniusly());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(FireContiniusly());
            firingCoroutine = null;
        }
    }

    float GetRandomFiringRate()
    {
        float spawnTime = Random.Range(firingRate - fireTimeVarience,
                                       firingRate + fireTimeVarience);
        return Mathf.Clamp(spawnTime, minimumFireRate, float.MaxValue);
    }

    IEnumerator FireContiniusly()
    {
        while (isFiring)
        {
            
            GameObject projectile = Instantiate(projectilePrefab, spawnPos.position, Quaternion.identity);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
            if(rigidbody != null) 
            {
                rigidbody.velocity = transform.up * projectileSpeed;                
            }
            Destroy(projectile, projectileLifetime);

            if (gameObject.tag == "Player")
            {
                audioPlayer.PlayShootingClip();
            }


            yield return new WaitForSeconds(GetRandomFiringRate());
            
        }
    }
}
