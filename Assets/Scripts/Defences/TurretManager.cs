using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject[] turrets;    //array of turrets, max 5
    public int turretsBought = 0;  //track current turret

    public void Start()
    {
        //ensures all turrets are hidden at the start of the game
        foreach (GameObject turret in turrets)
        {
            turret.SetActive(false);
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
}
