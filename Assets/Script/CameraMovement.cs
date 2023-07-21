using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float z;
    [SerializeField] private float topLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.transform.position;
        if (position.x > rightLimit) {
            position.x = rightLimit;
        } else if (position.x < leftLimit) {
            position.x = leftLimit;
        } 
        if (position.y > topLimit) {
            position.y = topLimit;
        } else if (position.y < bottomLimit) {
            position.y = bottomLimit;
        }
        transform.position = new Vector3(position.x, position.y, z);
    }
}
