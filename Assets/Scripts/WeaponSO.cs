using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Flock/Example/Weapon")]
public class WeaponSO : ScriptableObject
{
    public string name;
    public string description;
    public float damage;
    public float range;
    public float attackSpeed;

    public float DoDamage(float Armour)
    {
        return damage - Armour;
    }
}
