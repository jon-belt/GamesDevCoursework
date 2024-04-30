using System;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour, IDataPersistence
{
    public float health;
    private float maxHealth = 1000;
    private bool newGame;

    void Start()
    {   
        if (newGame == true)
        {
            health = maxHealth;
            newGame = false;
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            //game over
            Debug.Log("Spaceship was destroyed, GAME OVER...");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void LoadData(GameData data)
    {
        this.health = data.shipHealth;
        this.newGame = data.shipNewGame;
    }

    public void SaveData(ref GameData data)
    {
        newGame = false;        //This is a workaround to a bug i was having where it 'newGame = false' on line 15 never triggers
                                //When a game is being saved, this means the user has already played it.
                                //There are no save states currently, so I can always assume this is false on save

        data.shipHealth = this.health;
        data.shipNewGame = this.newGame;
    }
}
