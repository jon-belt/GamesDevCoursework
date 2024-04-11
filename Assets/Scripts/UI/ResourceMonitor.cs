using UnityEngine;
using TMPro;

public class ResourceMonitor : MonoBehaviour
{
    public PlayerInventory playerInventory;

    [SerializeField] private TextMeshProUGUI scrapText;
    [SerializeField] private TextMeshProUGUI oreText;
    [SerializeField] private TextMeshProUGUI woodText;

    private float scrapCount;
    private float oreCount;
    private float woodCount;

    void Start()
    {
        scrapCount = 0;
        oreCount = 0;
        woodCount = 0;
    }

    void Update()
    {
        scrapCount = playerInventory.GetBalance();
        scrapText.text = $"{scrapCount}";

        oreCount = playerInventory.GetOre();
        oreText.text = $"{oreCount}";

        woodCount = playerInventory.GetWood();
        woodText.text = $"{woodCount}";        
    }
}
