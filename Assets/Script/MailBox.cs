using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailBox : MonoBehaviour
{
    [SerializeField] private int day;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (day > PlayerData.levelsCompleted)
            PlayerData.levelsCompleted = day;
            SceneManager.LoadScene("LevelMenu");
        }
    }
}
