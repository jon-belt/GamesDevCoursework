using UnityEngine;
using UnityEngine.AI;

public class Walls : MonoBehaviour
{
    public GameObject walls;
    public BuyWalls buyWalls;

    // Start is called before the first frame update
    void Start()
    {
        if (buyWalls.isPurchased() == true)
        {
            walls.SetActive(true);
        }
        else{
            walls.SetActive(false);
        }
    }
}
