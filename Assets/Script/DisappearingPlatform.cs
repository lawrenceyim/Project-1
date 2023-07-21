using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private bool jumpedOn;
    [SerializeField] private float disappearAfter;
    [SerializeField] private float disappearAt;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")) {
            jumpedOn = true;
            disappearAt = Time.time + disappearAfter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpedOn && Time.time >= disappearAt) {
            Destroy(gameObject);
        }    
    }
}
