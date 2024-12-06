using System;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : Shooter
{
    public Transform target;
    public float detectionRange = 20f;


    private void Awake()
    {
        GameManager.enemies++;
    }

    void Update()
    {
        if (target == null) return; 
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        
        if (distanceToTarget <= detectionRange && canFire)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            StartCoroutine(fire());
        }
    }
}