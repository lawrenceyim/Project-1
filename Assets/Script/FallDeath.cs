using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float fallDeathY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= fallDeathY) {
            player.transform.position = new Vector3(0, 0, 0);
        }
    }
}
