using UnityEngine;

public class TriggerClick : MonoBehaviour
{
    public GameObject targetObject; // Объект, который будет двигаться
    public float offsetX = 0f; // Смещение по оси X
    public float offsetY = 0f; // Смещение по оси Y
    public float offsetZ = 0f; // Смещение по оси Z

    void OnMouseDown()
    {
            Mover mover = targetObject.GetComponent<Mover>();
            if (mover != null)
            {
                Vector3 destination = targetObject.transform.position + new Vector3(offsetX, offsetY, offsetZ);
                mover.MoveTo(destination);
            }

    }
}
