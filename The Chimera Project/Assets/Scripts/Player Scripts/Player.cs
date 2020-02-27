using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;

    public Text healthText;

    public GameObject enemy;

    private Rigidbody2D rb2d;
    private Animator anim;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        SetHealthText();

        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            currentHealth -= 10;
            SetHealthText();
        }
    }

    private void Update()
    {
        if(currentHealth > maxHealth)
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
