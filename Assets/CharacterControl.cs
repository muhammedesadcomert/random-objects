using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 velocity;
    
    float speedAmount = 3f;
    float jumpAmount = 7.1f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && Mathf.Approximately(rb2d.velocity.y, 0))
            rb2d.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);

        if (Input.GetAxisRaw("Horizontal") == -1)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else if (Input.GetAxisRaw("Horizontal") == 1)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (rb2d.transform.position.y <= -6.5f)
            Application.LoadLevel(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
