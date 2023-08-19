using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spawner", menuName = "Spanwer/Enemy")]
public class SpawnerData : ScriptableObject
{
    [Header("Info")] 
    public new string name;

    [Header("Spawning")] 
    public float spawnRate;
    public float maxSpawnable;
    public float amountSpawned;
}
