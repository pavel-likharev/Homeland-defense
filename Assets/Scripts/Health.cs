using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShake;
    [SerializeField] int scoreValue = 120;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    GameManager gameManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public int GetHealth()
    {
        return health; 
    }

    void TakeDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
    
        if (health <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                scoreKeeper.ChangeScore(scoreValue);
            }
            else
            {
                gameManager.OnGameOver();
            }

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
