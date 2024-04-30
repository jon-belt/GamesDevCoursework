using System;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDataPersistence
{
    private string[] enemyPositions;
    public int enemyNum;

    public GameObject enemyPrefab;

    //serialize Vector3 to string format "x_y_z"
    public static string SerializeVector3(Vector3 vector)
    {
        return $"{vector.x}_{vector.y}_{vector.z}";
    }

    //deserialize string in format "x_y_z" back to vector3
    public static Vector3 DeserializeVector3(string vectorString)
    {
        string[] splitString = vectorString.Split('_');
        if (splitString.Length != 3)
        {
            Debug.LogError("String format incorrect, unable to parse Vector3");
            return Vector3.zero;
        }

        float x, y, z;
        if (float.TryParse(splitString[0], out x) && float.TryParse(splitString[1], out y) && float.TryParse(splitString[2], out z))
        {
            return new Vector3(x, y, z);
        }
        else
        {
            Debug.LogError("Unable to parse Vector3");
            return Vector3.zero;
        }
    }

    public void LoadData(GameData data)
    {

        this.enemyNum = data.enemyNum;
        this.enemyPositions = data.enemyPositions;

        for (int i = 0; i < enemyNum; i++)
        {
            Vector3 position = DeserializeVector3(enemyPositions[i]);
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }

    public void SaveData(ref GameData data)
    {
        //also saves each enemy based of their positions
        //find all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNum = enemies.Length;
        enemyPositions = new string[enemies.Length];

        //store pos of each enemy
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyPositions[i] = SerializeVector3(enemies[i].transform.position);
        }

        //save
        data.enemyNum = this.enemyNum;
        data.enemyPositions = enemyPositions;
    }
}