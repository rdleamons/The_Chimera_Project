using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attack;
    public int enemyAttack;

    public int currentHealth = 100;
    public int maxHealth = 100;
    public int enemyHealth = 25;

    private bool enemyNear;
    public bool enemyDead;

    public Text healthText;

    public GameObject thisOne;

    private Rigidbody2D rb2d;
    private Animator anim;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        SetHealthText();

        currentHealth = maxHealth;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            enemyNear = true;
            thisOne = col.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & enemyNear)
        {
            attack = Random.Range(1, 16);
            enemyAttack = Random.Range(1, 11);

            if (enemyAttack >= 5)
            {
                currentHealth -= enemyAttack;
            }
            enemyHealth -= attack;
            SetHealthText();
        }

        if(enemyHealth <= 0)
        {
            enemyDead = true;
        }else
        {
            enemyDead = false;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
}
