using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Sprite[] animationFrames;
    [SerializeField] private float changeFrameInterval;
    private SpriteRenderer spriteRenderer;
    private int currentFrameIndex = 0;
    private float nextFrameChangeIn;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nextFrameChangeIn = Time.time + changeFrameInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFrameChangeIn) {
            nextFrameChangeIn = Time.time + changeFrameInterval;
            currentFrameIndex++;
            if (currentFrameIndex >= animationFrames.Length) {
                currentFrameIndex = 0;
            }
            spriteRenderer.sprite = animationFrames[currentFrameIndex];
        }

    }
}
