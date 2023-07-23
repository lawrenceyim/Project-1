using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private GameObject[] resetObjects;
    private List<Vector3> startingPositions;

    void Start()
    {
        startingPositions = new List<Vector3>(); 
        for (int i = 0; i < resetObjects.Length; i++) {
            startingPositions.Add(resetObjects[i].transform.position);
        }
    }

    public void ResetObjects() {
        for (int i = 0; i < resetObjects.Length; i++) {
            resetObjects[i].SetActive(false);
            resetObjects[i].SetActive(true);
            resetObjects[i].transform.position = startingPositions[i];
        }
    }
}
