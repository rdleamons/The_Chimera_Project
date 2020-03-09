using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool inCombat;
    public float wanderTime;
    public float moveSpeed = 1f;

    public Rigidbody2D rb;

    GameObject thePlayer;
    public Player player;

    Vector2 movement;

    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        player = thePlayer.GetComponent<Player>();
    }
    private void Update()
    {
        if(player.enemyDead == false)
        {
            if(wanderTime > 0)
            {
                transform.Translate(Vector3.forward * moveSpeed);
                wanderTime -= Time.deltaTime;
            }
            else
            {
                wanderTime = Random.Range(-1f, 1f);
                wander();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void wander()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }
}
