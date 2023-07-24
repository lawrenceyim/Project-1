using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private bool jumpedOn;
    private float jumpedOnAt;
    [SerializeField] private float disappearAfter;
    private int frameCount = 0;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")) {
            jumpedOn = true;
            jumpedOnAt = Time.time;
        }
    }

    void Update()
    {
        if (jumpedOn) {
            frameCount++;
            if (frameCount % 10 == 0) {
                Blink();
            }
        }
        if (jumpedOn && Time.time - jumpedOnAt >= disappearAfter) {
            gameObject.SetActive(false);
        }    
    }

    void Blink() {
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).CompareTag("Player")) continue;
            SpriteRenderer renderer = transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (renderer == null) {
                continue;
            }
            if (renderer.color == Color.red) {
                renderer.color = Color.white;
            } else {
                renderer.color = Color.red;
            }
        }
    }

    private void OnEnable() {
        ResetObject();
    }

    public void ResetObject() {
        for (int i = 0; i < transform.childCount; i++) {
            SpriteRenderer renderer = transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (renderer == null) {
                continue;
            }
            renderer.color = Color.white;
        }
        jumpedOn = false;
        frameCount = 0;
    }
}
