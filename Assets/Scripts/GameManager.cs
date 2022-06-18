using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    public int maxScore = 0;
    public string playerName;
    public string bestPlayer;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }
    
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerScore = maxScore;
        data.playerName = bestPlayer;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.playerScore;
            bestPlayer = data.playerName;
        }
    }
    
    public void ResetScore()
    {
        SaveData data = new SaveData();
        data.playerScore = maxScore = 0;
        data.playerName = bestPlayer = "";

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
