using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private BoxCollider2D collider2D;
    private bool checkForPlayer;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    private void Update() {
        if (checkForPlayer) {
            if (player.transform.position.y - .8f >= transform.position.y + .4f) {
                EnableCollision();
            } else {
                DisableCollision();
            }
        }
        // Vector3 position = transform.position;
        // position.y += .5f;
        // Debug.DrawRay(position, Vector2.right, Color.red);
        // Vector3 playerPosition = player.transform.position;
        // playerPosition.y -= .8f;
        // Debug.DrawRay(playerPosition, Vector3.left, Color.blue);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        checkForPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        checkForPlayer = false;
    }
    
    public void EnableCollision()
    {
        collider2D.enabled = true;
    }

    public void DisableCollision()
    {
        collider2D.enabled = false;
    }

    // private void Update() {
    //     Vector3 position = transform.position;
    //     position.y += .5f;
    //     Debug.DrawRay(position, Vector2.right, Color.red);
    //     Vector3 playerPosition = player.transform.position;
    //     playerPosition.y -= .8f;
    //     Debug.DrawRay(playerPosition, Vector3.left, Color.blue);
        
    // }
}
