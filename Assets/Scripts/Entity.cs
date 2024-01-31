using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    public int hitPoints;
    public int damage;
    public float speed;
}
