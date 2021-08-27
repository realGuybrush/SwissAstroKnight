using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics
{
    public int maxHealth = 100;
    public int health;
    public int maxArmor = 0;
    public int armor;

    public Characteristics()
    {
        health = maxHealth;
        armor = maxArmor;
    }
}
