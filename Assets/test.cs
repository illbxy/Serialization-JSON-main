using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Collider handCollider;  // Референс на коллайдер руки игрока

    private void Start()
    {
        if (handCollider != null)
        {
            Debug.Log("Hand Collider found and collision ignored.");
            Physics.IgnoreCollision(handCollider, GetComponent<Collider>());
        }
        else
        {
            Debug.LogError("Hand Collider is not assigned!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Collision with hand detected.");
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Trigger with hand detected.");
            Physics.IgnoreCollision(other, GetComponent<Collider>());
        }
    }

}
