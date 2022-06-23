
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    
    [SerializeField]public EnemysPool[] myPool;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CreateObject(5, 0);
        CreateObject(5, 1);
    }

    void CreateObject(int quantity, int indexPool)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject go = Instantiate(myPool[indexPool]._enemyPrefab, myPool[indexPool]._objectParent);
            go.SetActive(false);
            myPool[indexPool]._enemys.Add(go);
            go.name = $"{myPool[indexPool]._name}_{go.transform.GetSiblingIndex()}";
        }
    }


    public GameObject GetPoolObject(int indexPool)
    {
        for (int i = 0; i < myPool[indexPool]._enemys.Count; i++)
        {
            if (!myPool[indexPool]._enemys[i].gameObject.activeSelf)
            {
                myPool[indexPool]._enemys[i].SetActive(true);
                myPool[indexPool]._enemys[i].GetComponent<CharacterMove>().OnInitializeZombie();
                return myPool[indexPool]._enemys[i];
            }
        }
        CreateObject(1, indexPool);
        myPool[indexPool]._enemys[myPool[indexPool]._enemys.Count - 1].SetActive(true);
        myPool[indexPool]._enemys[myPool[indexPool]._enemys.Count - 1].GetComponent<CharacterMove>().OnInitializeZombie();
        return myPool[indexPool]._enemys[myPool[indexPool]._enemys.Count - 1];
    }    
}

[Serializable]
public class EnemysPool
{
    public string _name;
    public GameObject _enemyPrefab;
    public Transform _objectParent;
    public List<GameObject> _enemys;
}
