using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int key;
    private GameObject mailbox;

    void Start() {
        mailbox = GameObject.FindGameObjectWithTag("Mail Box");
        if (PlayerData.collected.Contains(key)) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (!PlayerData.collected.Contains(key)) {
                mailbox.GetComponent<MailBox>().AddLetterFound(key);
            }
            Debug.Log(PlayerData.collected);
            gameObject.SetActive(false);
        }
    }

    public int GetKey() {
        return key;
    }
}
