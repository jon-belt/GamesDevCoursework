using UnityEngine;
using UnityEngine.AI;

public class Walls : MonoBehaviour
{
    public GameObject walls;

    // Start is called before the first frame update
    void Start()
    {
        walls.SetActive(false);
    }
}
