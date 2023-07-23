using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadSign : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    
    private void Start() {
        textObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            textObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

        private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            textObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
