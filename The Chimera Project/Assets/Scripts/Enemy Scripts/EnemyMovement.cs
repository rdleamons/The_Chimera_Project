using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool inCombat;
    public float wanderTime;
    public float moveSpeed = 0.25f;

    public Rigidbody2D rb;

    GameObject thePlayer;
    public Player player;

    GameObject whichEnemy;

    Vector2 movement;

    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        player = thePlayer.GetComponent<Player>();
    }
    private void Update()
    {
        whichEnemy = player.thisOne;

        if(player.enemyDead == false)
        {
            if(wanderTime > 0)
            {
                wanderTime -= Time.deltaTime;
            }
            else
            {
                wanderTime = Random.Range(1f, 3f);
                wander();
            }
        }

        if (player.enemyNear == true)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 0.25f;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void wander()
    {
        movement.x = Random.Range(-10f, 10f);
        movement.y = Random.Range(-10f, 10f);
    }
}
