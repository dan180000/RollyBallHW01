﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoBehaviour
{
    protected abstract void Collect(Player player);
    [SerializeField] float movementSpeed = 1;
    protected float MovementSpeed 
    { 
        get 
        { 
            return movementSpeed; 
        } 
    }

    [SerializeField] ParticleSystem collectParticles;
    [SerializeField] AudioClip collectSound;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement(rb);
    }

    protected virtual void Movement(Rigidbody rb)
    {
        //calculate rotation
        Quaternion turnOffset = Quaternion.Euler(0, movementSpeed, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            Collect(player);
            //spawn particles & sfx; Disable object
            Feedback();

            gameObject.SetActive(false);
        }
    }

    private void Feedback()
    {
        if(collectParticles != null)
        {
            collectParticles = Instantiate(collectParticles, 
                transform.position, Quaternion.identity);
        }
        //audio. TODO - consider Object Pooling for performance
        if(collectSound != null)
        {
            AudioHelper.PlayClip2D(collectSound, 1f);
        }
    }
}
