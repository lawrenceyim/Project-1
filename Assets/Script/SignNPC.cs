using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignNPC : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject background;    
    [SerializeField] string message;
    private void Start() {
        textObject.GetComponent<MeshRenderer>().enabled = false;
        background.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            textObject.GetComponent<MeshRenderer>().enabled = true;
            textObject.GetComponent<TextMeshPro>().text = message;
            background.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

        private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            textObject.GetComponent<MeshRenderer>().enabled = false;
            background.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
