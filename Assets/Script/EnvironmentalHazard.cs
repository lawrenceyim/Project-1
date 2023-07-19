using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalHazard : MonoBehaviour
{
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            player.transform.position = new Vector3(0, 0, 0);
        }
    }

}
