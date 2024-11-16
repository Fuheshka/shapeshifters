using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON_FOR_FALL : MonoBehaviour
{
    public GameObject sphere; // Ссылка на существующую сферу
    private void OnTriggerEnter(Collider other) { 
        // Проверяем, что коллайдер принадлежит герою (можете заменить "Player" на тег вашего героя)
        if (other.CompareTag("Player2") || other.CompareTag("Player1")) 
        { 
        // Проверяем, если у сферы уже есть компонент Rigidbody, то добавляем его, если нет
            if (!sphere.GetComponent<Rigidbody>()) 
            {
                Rigidbody rb = sphere.AddComponent<Rigidbody>(); 
                // Можно настроить параметры Rigidbody, если необходимо
                rb.mass = 1;
                rb.drag = 1f; 
                rb.angularDrag = 0.05f; 
            } 
        }
    }
}

