using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player")]
public class PlayerData : ScriptableObject
{
    [Header("Info")] 
    public float health;
    public Vector3 position;
    public Quaternion rotation;
}
