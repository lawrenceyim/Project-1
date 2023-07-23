using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float fallDeathY;
    [SerializeField] private Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= fallDeathY) {
            gameObject.GetComponent<Reset>().ResetObjects();
            player.transform.position = spawn;
        }
    }
}
