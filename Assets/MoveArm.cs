using UnityEngine;

public class MoveArm : MonoBehaviour
{
    public float speed = 10f; // Скорость движения
    public bool moveAlongX = true; // Флаг для определения движения только по оси X

    void Update()
    {
        if (Input.GetMouseButton(0)) // Проверяем, нажата ли кнопка мыши (левая кнопка)
        {
            // Получаем текущие координаты мыши
            Vector3 mousePosition = Input.mousePosition;
            // Преобразуем экранные координаты в мировые координаты
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - Camera.main.transform.position.z));

            // Определяем новую позицию только по оси X или Y в зависимости от настроек
            Vector3 newPosition = transform.position;
            if (moveAlongX)
            {
                newPosition.x = worldPosition.x;
            }
            else
            {
                newPosition.y = worldPosition.y;
            }

            // Плавно перемещаем объект к новой позиции
            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
    }
}
