using System.IO;
using UnityEngine;
using Valve.Newtonsoft.Json;
using System;
using UnityEngine.UI;

[Serializable]
public class PlayerData
{
    public string className;
    public string educationLevel;
    public int age;
}


public class PlayerDataManager : MonoBehaviour
{
    public PlayerData playerData;
    public Text classText;
    public Text educationText;
    public Text ageText;
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        if (!File.Exists(filePath))
        {
            GenerateInitialData();
            SavePlayerData();
        }
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerData = JsonConvert.DeserializeObject<PlayerData>(json);
        }
        DisplayPlayerData();
    }

    private void SavePlayerData()
    {
        string json = JsonConvert.SerializeObject(playerData, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    private void GenerateInitialData()
    {
        playerData = new PlayerData
        {
            className = "оператор станка",
            educationLevel = "младший",
            age = 20
        };
    }

    private void DisplayPlayerData()
    {
        if (classText != null)
        {
            classText.text = $"Class: {playerData.className}";
        }
        if (educationText != null)
        {
            educationText.text = $"Education Level: {playerData.educationLevel}";
        }
        if (ageText != null)
        {
            ageText.text = $"Age: {playerData.age}";
        }
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
}
