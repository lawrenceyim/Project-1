using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelStarter : MonoBehaviour
{
    private void OnMouseDown() {
        string sceneName = "Level " + GetComponent<TextMeshPro>().text;
        SceneManager.LoadScene(sceneName);
    }
}
