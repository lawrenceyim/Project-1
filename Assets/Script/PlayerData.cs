using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";
    public static int levelsCompleted;
    // List are the only serializable collection
    public static List<int> collected;


    [RuntimeInitializeOnLoadMethod]
    static void RunOnGameStart()
    {
        if (File.Exists(Application.dataPath + "/save.txt")) {
            LoadData();
        } else {
            ResetSave();
        }
    }

    public static void SaveData() {
        SaveObject saveObject = new SaveObject();
        saveObject.levelsCompleted = levelsCompleted;
        saveObject.collected = collected;
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    public static void LoadData() {
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
        levelsCompleted = saveObject.levelsCompleted;
        collected = saveObject.collected;
        Debug.Log(saveString);
    }

    public static void ResetSave() {
        collected = new List<int>();
        levelsCompleted = 0;
        SaveData();
    }

    private class SaveObject {
        public int levelsCompleted;
        public List<int> collected;
    }
}
