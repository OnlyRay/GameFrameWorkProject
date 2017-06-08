using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager  {

    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        }
    }

    private static string poolConfigPathPrefix = "Assets/Framework/Resources/";
    private const string poolConfigPathMiddle = "gameobjectpool";
    private const string poolConfigPathPostfix = "asset";

    public static string PoolConfigPath
    {
        get
        {
            return poolConfigPathPrefix + poolConfigPathMiddle + poolConfigPathPostfix;
        }
    }

    private Dictionary<string, GameObjectPool> poolDict;

    private PoolManager()
    {//读取池子里的东西
        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(poolConfigPathMiddle);
        poolDict = new Dictionary<string, GameObjectPool>();
        foreach (GameObjectPool pool in poolList.poolList)
        {
            poolDict.Add(pool.name, pool);
        }
    }

    public void Init()
    {

    }

    public GameObject GetInst(string poolName)
    {
        GameObjectPool pool;
        if(poolDict.TryGetValue(poolName, out pool))
        {
            return pool.GetInst();
        }
        Debug.LogWarning("Pool: " + poolName + "is not exist!");
        return null;
    }
}
