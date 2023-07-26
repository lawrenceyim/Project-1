using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    [SerializeField] private float bounceForce;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 velocity = rb.velocity;
            velocity.y = 1f * bounceForce;
            rb.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}
