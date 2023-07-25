using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (Mathf.Abs(other.gameObject.GetComponent<Rigidbody2D>().velocity.x) > 7) {
                gameObject.SetActive(false);
            }
        }
    }
 
}
