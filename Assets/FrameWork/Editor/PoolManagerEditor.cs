using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoolManagerEditor {
    [MenuItem("Manager/CreateGamaObjectPoolConfig")]//创建GameObjectPool的对象的方法
	static void CreateGameObjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();//把这个保存为配置文件
        string path = PoolManager.PoolConfigPath;
        AssetDatabase.CreateAsset(poolList, path);
        AssetDatabase.SaveAssets();
    }
}
