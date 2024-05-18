using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    GameObject enemy;
    InGame gamePoints;
    
    float ray = 1.5f;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        gamePoints = FindObjectOfType<InGame>();
        if (gamePoints == null)
        {
            Debug.LogError("InGame component not found in the scene!");
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 position = new Vector2(mousePosition.x - (player.transform.position.x + ray), mousePosition.y - (player.transform.position.y + ray)).normalized;
        transform.position = (position * ray) + (Vector2)player.transform.position;
        transform.up = position;
    }

    // Use OnTriggerEnter2D para detectar a colisão com o inimigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gamePoints.points += 1;
        }
    }
}
