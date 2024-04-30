using UnityEngine;

public class PlayerPosition : MonoBehaviour, IDataPersistence
{
    public GameObject player;
    private bool newGame = true;

    void Start()
    {
        if (newGame)
        {
            transform.position = new Vector3(159, 32, -562);
        }
        else
        {
            LoadPosition();
        }
    }

    private void LoadPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX", 159);
        float y = PlayerPrefs.GetFloat("PlayerY", 32);
        float z = PlayerPrefs.GetFloat("PlayerZ", -562);
        transform.position = new Vector3(x, y, z);
    }

    private void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        PlayerPrefs.Save();
    }

    public void LoadData(GameData data)
    {
        newGame = data.playerPosNewGame;
        if (!newGame)
        {
            LoadPosition();
        }
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosNewGame = false;
        SavePosition();
    }
}
