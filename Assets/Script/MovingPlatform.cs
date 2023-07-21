using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2[] positions;
    [SerializeField] private float speed;
    private int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.Equals(positions[index])) {
            index = (index + 1) % positions.Length;
        }
        transform.position = Vector2.MoveTowards(transform.position, positions[index], speed * Time.deltaTime);
    }
}
