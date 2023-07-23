using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalHazard : MonoBehaviour
{
    [SerializeField] private Vector3 spawn;
    
    void Start()
    {
        spawn =  GameObject.FindGameObjectWithTag("Player").transform.position;   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("Level Manager").GetComponent<Reset>().ResetObjects();
            other.gameObject.transform.position = spawn;
            other.gameObject.transform.SetParent(null);
        }
    }

}
