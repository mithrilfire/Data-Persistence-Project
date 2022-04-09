using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    string savePath;
    public string PlayerName { get; set; }
    public string HighScoreName { get; set; }
    public int HighScore { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath + "/savefile.json";
        LoadGame();
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        data.HighScoreName = HighScoreName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savePath, json);
    }


    public void LoadGame()
    {

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName = data.HighScoreName;
            HighScore = data.HighScore;
        }
    }
}
