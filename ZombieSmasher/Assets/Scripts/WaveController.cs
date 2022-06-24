using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController Instance;

    [SerializeField] private int levelIndex;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int waveIndex;
    [SerializeField] private float ratio;

    IEnumerator pattern;

    public int movementSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OnStartWave()
    {
        if (pattern != null)
        {
            StopCoroutine(pattern);
        }
        pattern = SelectorPattern(waveIndex);
        StartCoroutine(pattern);
    }

    IEnumerator SelectorPattern(int index)
    {
        switch (index)
        {
            case 1:
                //Linea horizontal
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    GameObject go = PoolManager.Instance.GetPoolObject(0);
                    go.transform.position = spawnPoints[i].position;
                }
                break;
            case 2:
                //Linea Diagonal
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    GameObject go = PoolManager.Instance.GetPoolObject(0);
                    go.transform.position = spawnPoints[i].position;
                    yield return new WaitForSeconds(ratio);
                }
                break;
            case 3:
                for (int i = spawnPoints.Length -1 ; i >= 0; i--)
                {
                    GameObject go = PoolManager.Instance.GetPoolObject(0);
                    go.transform.position = spawnPoints[i].position;
                    yield return new WaitForSeconds(ratio);
                }
                break;
        }
    }
}
