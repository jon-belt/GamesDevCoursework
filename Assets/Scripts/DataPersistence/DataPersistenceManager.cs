// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;
// using System.IO;

// public class DataPersistenceManager : MonoBehaviour
// {
//     [Header("File Storage Config")]
//     [SerializeField] private string fileName;


//     private GameData gameData;
//     private List<IDataPersistence> dataPersistenceObjects;
//     private FileDataHandler dataHandler;

//     public static DataPersistenceManager instance { get; private set; }

//     private void Awake()
//     {
//         if (instance != null)
//         {
//             Debug.LogError("More than one DataPersistanceManager found.");
//         }
//         instance = this;
//     }

//     private void Start()
//     {
//         this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
//         this.dataPersistenceObjects = FindAllDataPersistentObjects();
//         LoadGame();
//     }

//     public void NewGame()
//     {
//         this.gameData = new GameData();
//     }

//     public void LoadGame()
//     {
//         this.gameData = dataHandler.Load();

//         if(this.gameData == null)
//         {
//             Debug.Log("No data found, setting to default values");
//             NewGame();
//         }
//         foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
//         {
//             dataPersistenceObj.LoadData(gameData);
//         }

//         Debug.Log("Loaded Bal Count: " + gameData.balance);
//     }

//     public void SaveGame()
//     {
//         foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
//         {
//             dataPersistenceObj.SaveData(ref gameData);
//         }

//         Debug.Log("Saved Bal Count: " + gameData.balance);

//         //save data to file using dataHandler
//         dataHandler.Save(gameData);
//     }

//     private void OnApplicationQuit()
//     {
//         SaveGame();
//     }

//     private List<IDataPersistence> FindAllDataPersistentObjects()
//     {
//         IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

//         return new List<IDataPersistence>(dataPersistenceObjects);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    private bool dataApplied = false;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistentObjects();
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if(gameData == null)
        {
            Debug.Log("No data found, setting to default values");
            NewGame();
        }

        var buttonDataList = dataHandler.LoadButtonData();
        ApplyButtonData(buttonDataList);

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded Game Data");
    }

    public void SaveGame()
    {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        //find and save button data
        var buttonDataList = CollectButtonData();
        dataHandler.SaveButtonData(buttonDataList);

        dataHandler.SaveGameData(gameData);
        Debug.Log("Game Data Saved");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistentObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    private List<ButtonSaveData> CollectButtonData()
    {
        ButtonBase[] buttons = FindObjectsOfType<ButtonBase>(true);
        List<ButtonSaveData> buttonDataList = new List<ButtonSaveData>();
        foreach (var button in buttons)
        {
            buttonDataList.Add(button.GetSaveData());
        }
        return buttonDataList;
    }

    private void ApplyButtonData(List<ButtonSaveData> buttonDataList)
    {
        ButtonBase[] buttons = FindObjectsOfType<ButtonBase>(true); // true to find inactive objects
        foreach (var button in buttons)
        {
            var data = buttonDataList.Find(b => b.buttonType == button.GetType().ToString());
            if (data != null)
            {
                button.SetSaveData(data);
                Debug.Log($"Data applied to {button.GetType()}: Cost = {data.currentUpgradeCost}, Count = {data.upgradeCount}");
            }
        }
    }

    public void ApplyDataWhenReady()
    {
        if (!dataApplied) {
            var buttonDataList = dataHandler.LoadButtonData();
            ApplyButtonData(buttonDataList);
            dataApplied = true;
        }
    }
}
