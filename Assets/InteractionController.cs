using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private bool isInInteractionZone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractionZone"))
        {
            isInInteractionZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractionZone"))
        {
            isInInteractionZone = false;
        }
    }

    void Update()
    {
        if (isInInteractionZone && Input.GetKeyDown(KeyCode.E)) // Replace with VR interaction input
        {
            // Code to allow interaction, e.g., picking up the object
        }
    }
}
