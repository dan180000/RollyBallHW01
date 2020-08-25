﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] GameObject impactParticles;
    [SerializeField] AudioClip impactSound;

    Rigidbody rb;
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            PlayerImpact(player);
            ImpactFeedback();
        }
    }

    protected virtual void PlayerImpact(Player player)
    {
        player.DecreaseHealth(damageAmount);
    }

    private void ImpactFeedback()
    {
        if (impactParticles != null)
        {
            impactParticles = Instantiate(impactParticles, 
                transform.position, Quaternion.identity);
        }
        if (impactSound != null)
        {
            AudioHelper.PlayClip2D(impactSound, 1f);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        
    }
}
