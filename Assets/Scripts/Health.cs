using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void TakeDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
    
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer);
            PlayHitEffect();
            audioPlayer.PlayDamagingClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake) 
        {
            cameraShake.PlayShake();
        }
    }
}
