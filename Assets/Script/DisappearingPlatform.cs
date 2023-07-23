using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private bool jumpedOn;
    [SerializeField] private float disappearAfter;
    private float jumpedOnAt;
    private int frameCount = 0;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")) {
            jumpedOn = true;
            jumpedOnAt = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpedOn) {
            frameCount++;
            if (frameCount % 10 == 0) {
                Blink();
            }
        }
        if (jumpedOn && Time.time - jumpedOnAt >= disappearAfter) {
            Destroy(gameObject);
        }    
    }

    void Blink() {
        for (int i = 0; i < transform.childCount; i++) {
            SpriteRenderer sr = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if (sr != null) {
                if (sr.color != Color.red) {
                    sr.color = Color.red;
                } else {
                    sr.color = Color.white;
                }
            }
        }
    }
}
