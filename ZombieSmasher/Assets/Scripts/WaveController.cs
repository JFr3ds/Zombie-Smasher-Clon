using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController Instance;

    [SerializeField] private int levelIndex;
    [SerializeField] private CharacterMove[] characters;
    [SerializeField] private Transform[] spawnPoints;

    public int movementSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }




}
