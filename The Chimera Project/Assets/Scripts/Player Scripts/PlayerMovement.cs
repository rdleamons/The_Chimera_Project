using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float originalMoveSpeed = 5f;
    public float stamina = 20.0f;
    private float maxStamina = 20.0f;

    public Rigidbody2D rb;

    public StaminaBar staminaBar;

    Vector2 movement;

    private void Start()
    {
        stamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("StaminaPack"))
        {
            stamina += 5;
            col.gameObject.SetActive(false);
            staminaBar.SetStamina(stamina);
        }
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        staminaBar.SetStamina(stamina);

        if (Input.GetKeyDown(KeyCode.LeftShift) & stamina == maxStamina)
        {
            CancelInvoke();
            moveSpeed = moveSpeed * 2;
            InvokeRepeating("loseStamina", 0, 0.1f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || stamina == 0)
        {
            CancelInvoke();
            moveSpeed = originalMoveSpeed;
            InvokeRepeating("gainStamina", 0, 0.1f);
        }

        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void loseStamina()
    {
        stamina--;
    }

    private void gainStamina()
    {
        stamina += 0.5f;
    }
}