using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Transform door; // Ссылка на объект двери
    public float openHeight = 5.0f; // Высота открытия двери
    public float doorSpeed = 2.0f; // Скорость движения двери
    public float tolerance = 0.01f; // Допустимая погрешность для остановки двери

    public string playerTag; // Тег игрока, который активирует эту дверь (Player1 или Player2)

    private bool isPlayerNearby = false; // Отслеживает, находится ли правильный игрок рядом
    private bool isPlayerUnderDoor = false; // Переменная для проверки, находится ли игрок под дверью

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private bool isMoving = false; // Флаг для контроля движения двери

    void Start()
    {
        closedPosition = door.position;
        openPosition = new Vector3(door.position.x, door.position.y + openHeight, door.position.z);
    }

    void Update()
    {
        // Проверка, есть ли игрок под дверью
        isPlayerUnderDoor = CheckIfPlayerUnderDoor();

        if (isPlayerNearby && !isMoving) // Открываем дверь, если игрок рядом
        {
            StartCoroutine(MoveDoor(openPosition));
        }
        else if (!isPlayerNearby && !isPlayerUnderDoor && !isMoving) // Закрываем дверь, если игрок не рядом и не под дверью
        {
            StartCoroutine(MoveDoor(closedPosition));
        }
    }

    // Корутина для плавного перемещения двери
    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        isMoving = true;

        while (Vector3.Distance(door.position, targetPosition) > tolerance)
        {
            door.position = Vector3.Lerp(door.position, targetPosition, doorSpeed * Time.deltaTime);
            yield return null;
        }

        door.position = targetPosition;
        isMoving = false;
    }

    // Проверка, находится ли игрок под дверью с помощью Raycast
    private bool CheckIfPlayerUnderDoor()
    {
        RaycastHit hit;

        // Стреляем лучом вниз из центра двери
        if (Physics.Raycast(door.position, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag(playerTag)) // Проверяем, если игрок под дверью
            {
                return true;
            }
        }

        return false;
    }

    // Игрок входит в зону триггера
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = true;
        }
    }

    // Игрок выходит из зоны триггера
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = false;
        }
    }
}
