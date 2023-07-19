using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float z;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, z);
    }
}
