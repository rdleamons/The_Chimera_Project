using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int stamina = 20;
    private int maxStamina = 20;

    public Rigidbody2D rb;

    public StaminaBar staminaBar;

    Vector2 movement;

    private void Start()
    {
        stamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        staminaBar.SetStamina(stamina);

        if (Input.GetKeyDown(KeyCode.LeftShift) & stamina == maxStamina)
        {
            CancelInvoke();
            moveSpeed = 10f;
            InvokeRepeating("loseStamina", 0, 0.1f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || stamina == 0)
        {
            CancelInvoke();
            moveSpeed = 5f;
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
        stamina++;
    }
}