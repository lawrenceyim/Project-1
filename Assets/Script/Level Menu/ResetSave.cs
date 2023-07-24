using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSave : MonoBehaviour
{
    private void OnMouseDown() {
        PlayerData.ResetSave();
        SceneManager.LoadScene("LevelMenu");
    }
}
