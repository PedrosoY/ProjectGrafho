using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float loseDistance = 2f;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject gameOverScreen;
    private Animator anim;
    private Rigidbody2D rig;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        gameOverScreen.SetActive(false);
    }

    void FixedUpdate()
    {
        Move();
        //CheckLose();
    }

    void Move()
    {
        float movementVertical = Input.GetAxisRaw("Vertical");
        float movementHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(movementHorizontal, movementVertical).normalized * speed * Time.deltaTime;
        rig.MovePosition(rig.position + movement);

        int transition = 0;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("SAI DO JOGO");
            Application.Quit();
        }

            if (movementHorizontal != 0)
        {
            transition = (movementHorizontal > 0) ? 1 : 2;
        }
        else if (movementVertical != 0)
        {
            transition = (movementVertical > 0) ? 3 : 4;
        }

        anim.SetInteger("transition", transition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Perdeu");
            gameOverScreen.SetActive(true);  // Show the GameOver screen
            Time.timeScale = 0f;  // Pause the game
        }
    }
    
}
