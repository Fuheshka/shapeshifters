using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Transform door; // ������ �� ������ �����
    public float openHeight = 5.0f; // ������ �������� �����
    public float doorSpeed = 2.0f; // �������� �������� �����
    public float tolerance = 0.01f; // ���������� ����������� ��� ��������� �����

    public string playerTag; // ��� ������, ������� ���������� ��� ����� (Player1 ��� Player2)

    private bool isPlayerNearby = false; // �����������, ��������� �� ���������� ����� �����
    private bool isPlayerUnderDoor = false; // ���������� ��� ��������, ��������� �� ����� ��� ������

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private bool isMoving = false; // ���� ��� �������� �������� �����

    void Start()
    {
        closedPosition = door.position;
        openPosition = new Vector3(door.position.x, door.position.y + openHeight, door.position.z);
    }

    void Update()
    {
        // ��������, ���� �� ����� ��� ������
        isPlayerUnderDoor = CheckIfPlayerUnderDoor();

        if (isPlayerNearby && !isMoving) // ��������� �����, ���� ����� �����
        {
            StartCoroutine(MoveDoor(openPosition));
        }
        else if (!isPlayerNearby && !isPlayerUnderDoor && !isMoving) // ��������� �����, ���� ����� �� ����� � �� ��� ������
        {
            StartCoroutine(MoveDoor(closedPosition));
        }
    }

    // �������� ��� �������� ����������� �����
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

    // ��������, ��������� �� ����� ��� ������ � ������� Raycast
    private bool CheckIfPlayerUnderDoor()
    {
        RaycastHit hit;

        // �������� ����� ���� �� ������ �����
        if (Physics.Raycast(door.position, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag(playerTag)) // ���������, ���� ����� ��� ������
            {
                return true;
            }
        }

        return false;
    }

    // ����� ������ � ���� ��������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = true;
        }
    }

    // ����� ������� �� ���� ��������
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = false;
        }
    }
}
