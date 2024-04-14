using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        //reads file and parses data back into gameData object
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                //deserialise back into c# readable code
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.Log("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData gameData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create dir path if it doesnt exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialise to c# game data object to json
            string dataToStore = JsonUtility.ToJson(gameData, true);

            //write file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured whilst saving data to file: " + fullPath + "\n" + e);
        }
    }

    public void SaveButtonData(List<ButtonSaveData> buttonData)
    {
        if (buttonData == null || buttonData.Count == 0)
        {
            Debug.LogError("No button data to save.");
            return;
        }
        // foreach(var data in buttonData) {
        //     Debug.Log($"Saving Button Data: Type={data.buttonType}, Cost={data.currentUpgradeCost}, Count={data.upgradeCount}");
        // }
        string buttonDataPath = Path.Combine(dataDirPath, "buttonData.json");
        string dataToStore = JsonUtility.ToJson(new Serialization<ButtonSaveData>(buttonData), true);
        File.WriteAllText(buttonDataPath, dataToStore);
    }

    public List<ButtonSaveData> LoadButtonData()
    {
        string buttonDataPath = Path.Combine(dataDirPath, "buttonData.json");
        if (File.Exists(buttonDataPath))
        {
            string dataToLoad = File.ReadAllText(buttonDataPath);
            Debug.Log($"Loaded Button Data: {dataToLoad}");
            var data = JsonUtility.FromJson<Serialization<ButtonSaveData>>(dataToLoad);
            if (data != null && data.items != null)
                return data.items;
            else
                Debug.LogError("Failed to deserialize button data or no items found.");
        }
        else
        {
            Debug.Log("No button data file found.");
        }
        return new List<ButtonSaveData>();
    }

    [System.Serializable]
    private class Serialization<T>
    {
        public List<T> items;

        public Serialization(List<T> items)
        {
            this.items = items;
        }

        public List<T> ToList() => items;
    }

    public void SaveGameData(GameData gameData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        string dataToStore = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(fullPath, dataToStore);
    }
}