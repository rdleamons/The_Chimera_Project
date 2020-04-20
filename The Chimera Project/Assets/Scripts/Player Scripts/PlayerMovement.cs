using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int stamina = 2;
    private int maxStamina = 2;

    public Rigidbody2D rb;

    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) & stamina > 0)
        {
            CancelInvoke();
            moveSpeed = 10f;
            InvokeRepeating("loseStamina", 0, 0.5f);
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