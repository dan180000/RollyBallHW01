using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    [SerializeField] float powerUpDuration = 5;
    [SerializeField] ParticleSystem collectParticles;
    [SerializeField] AudioClip collectSound;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            //spawn particles & sfx; Disable object
            Feedback();
            gameObject.SetActive(false);
            powerUpDuration -= Time.deltaTime;
            Debug.Log("Power Up");
            if (powerUpDuration <= 0)
            {
                PowerDown(player);
                Debug.Log("Power Down");
            }
            
        }
    }

    private void Feedback()
    {
        if (collectParticles != null)
        {
            collectParticles = Instantiate(collectParticles,
                transform.position, Quaternion.identity);
        }
        //audio. TODO - consider Object Pooling for performance
        if (collectSound != null)
        {
            AudioHelper.PlayClip2D(collectSound, 1f);
        }
    }

}
