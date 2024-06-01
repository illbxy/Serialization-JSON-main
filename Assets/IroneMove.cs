using UnityEngine;

public class MoverIrone : MonoBehaviour
{
    public float speed = 5f; // Скорость движения
    public float returnDelay = 10.0f; // Задержка перед возвратом
    private Vector3 initialPosition; // Начальная позиция
    private Vector3 targetPosition; // Конечная позиция
    private bool isMoving = false;

    void Start()
    {
        // Сохраняем начальную позицию
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false;
                Invoke("ReturnToInitialPosition", returnDelay); // Вызываем возврат через задержку
            }
        }
    }

    public void MoveTo(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    void ReturnToInitialPosition()
    {
        MoveTo(initialPosition); // Возвращаемся на начальную позицию
    }
}
