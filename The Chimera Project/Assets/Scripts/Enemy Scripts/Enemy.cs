using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth = 25;
    public int maxHealth = 25;
    public int enemyAttack;

    public GameObject playerObj;
    public GameObject enemy;

    private Rigidbody2D rb2d;
    private Animator anim;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            currentHealth -= 10;
        }
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(enemy);
    }

}

