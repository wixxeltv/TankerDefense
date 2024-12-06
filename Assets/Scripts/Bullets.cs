using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Rigidbody rb { get; private set; }
    public GameObject collisionEffect;
    public float damage = 25f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision coll)
    {
        HP hpComponent = coll.gameObject.GetComponent<HP>();
        if (hpComponent != null)
        {
            hpComponent.TakeDamage(damage);
        }
        if (collisionEffect != null)
        {
            Instantiate(collisionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}