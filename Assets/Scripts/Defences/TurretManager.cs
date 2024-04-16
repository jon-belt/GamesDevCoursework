using UnityEngine;

public class TurretManager : MonoBehaviour, IDataPersistence
{
    public GameObject[] turrets;    //array of turrets, max 5
    public int turretsBought = 0;  //track current turret

    public void Start()
    {
        //sets all to be hidden
        foreach (GameObject turret in turrets)
        {
            turret.SetActive(false);
        }

        int numTurretsToActivate = Mathf.Min(turretsBought, turrets.Length);
        for (int i = 0; i < numTurretsToActivate; i++)
        {
            turrets[i].SetActive(true);
        }
    }

    public void UnlockTurret()
    {
        //if there are still turrets to be bought
        if (turretsBought < turrets.Length)
        {
            turrets[turretsBought].SetActive(true);     //activate next turret in sequence
            turretsBought++;
        }
        else
        {
            Debug.Log("All turrets have been bought.");
            //tell upgrade menu to change button + then disable button
        }
    }

    public void LoadData(GameData data)
    {
        this.turretsBought = data.turretNum;
    }

    public void SaveData(ref GameData data)
    {
        data.turretNum = this.turretsBought;
    }
}
