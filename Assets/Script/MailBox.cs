using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailBox : MonoBehaviour
{
    [SerializeField] private int day;
    [SerializeField] GameObject[] letters;
    private List<int> collectedLetters;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (day > PlayerData.levelsCompleted) {
                PlayerData.levelsCompleted = day;
            }
            for (int i = 0; i < collectedLetters.Count; i++) {
                PlayerData.collected.Add(collectedLetters[i]);
            }
            PlayerData.SaveData();
            SceneManager.LoadScene("LevelMenu");
        }
    }

    public void AddLetterFound(int key) {
        collectedLetters.Add(key);
    }

    public void ResetLettersFound() {
        for (int i = 0; i < letters.Length; i++) {
            if (!PlayerData.collected.Contains(letters[i].GetComponent<Collectable>().GetKey())) {
                letters[i].SetActive(true);
            }
        }
        collectedLetters = new List<int>();
    }
}
