using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenuGenerator : MonoBehaviour
{
    [SerializeField] private GameObject dayBlock;
    [SerializeField] private GameObject borderlessDayBlock;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    // Start is called before the first frame update
    void Start()
    {   
        Instantiate(borderlessDayBlock, new Vector3(1 + xOffset, 1 + yOffset, 0), Quaternion.identity).GetComponent<TextMeshPro>().text = "";
        Instantiate(borderlessDayBlock, new Vector3(2 + xOffset, 1 + yOffset, 0), Quaternion.identity).GetComponent<TextMeshPro>().text = "L";
        Instantiate(borderlessDayBlock, new Vector3(3 + xOffset, 1 + yOffset, 0), Quaternion.identity).GetComponent<TextMeshPro>().text = "E";
        Instantiate(borderlessDayBlock, new Vector3(4 + xOffset, 1 + yOffset, 0), Quaternion.identity).GetComponent<TextMeshPro>().text = "V";
        Instantiate(borderlessDayBlock, new Vector3(5 + xOffset, 1 + yOffset, 0), Quaternion.identity).GetComponent<TextMeshPro>().text = "E";
        Instantiate(borderlessDayBlock, new Vector3(6 + xOffset, 1 + yOffset, 0), Quaternion.identity).GetComponent<TextMeshPro>().text = "L";
        Instantiate(borderlessDayBlock, new Vector3(7 + xOffset, 1 + yOffset, 0), Quaternion.identity).GetComponent<TextMeshPro>().text = "";

        int day = 1;
        for (int i = 0; i < 4; i++) {
            for (int j = 1; j <= 7; j++) {
                GameObject temp = Instantiate(dayBlock, new Vector3(j + xOffset, -i + yOffset, 0), Quaternion.identity);
                temp.GetComponent<TextMeshPro>().text = day.ToString();
                if (day - 1 == PlayerData.levelsCompleted) {
                    temp.transform.Find("Green").GetComponent<SpriteRenderer>().enabled = true;
                    temp.GetComponent<LevelStarter>().MakeLevelAvailable();
                }
                if (day <= PlayerData.levelsCompleted) {
                    temp.transform.Find("Check").GetComponent<SpriteRenderer>().enabled = true;
                    temp.GetComponent<LevelStarter>().MakeLevelAvailable();
                }
                day++;
            }
        }           
    }
}
