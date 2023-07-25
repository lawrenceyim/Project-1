using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Vector3 position;
    private GameObject camera;

    private void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            camera.transform.position = position;
        }
    }
}
