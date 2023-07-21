using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private bool levelAvailable;
    private void OnMouseDown() {
        if (!levelAvailable) {
            return;
        }
        string sceneName = "Level " + GetComponent<TextMeshPro>().text;
        SceneManager.LoadScene(sceneName);
    }

    public void MakeLevelAvailable() {
        levelAvailable = true;
    }
}
