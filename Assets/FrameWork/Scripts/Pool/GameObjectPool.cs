using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个类是单独编辑一个资源池
[Serializable]//序列化
public class GameObjectPool {
    [SerializeField]//序列化，可直接编辑其中的值
    public string name;
    [SerializeField]//序列化，可直接编辑其中的值
    public GameObject prefab;
    [SerializeField]//序列化，可直接编辑其中的值
    public int maxAmount;
    [NonSerialized]//不需要序列化
    private List<GameObject> golist = new List<GameObject>();
    //这个方法是表示从资源池中获取一个实例
    public GameObject GetInst()
    {
        foreach (GameObject go in golist)
        {
            if (go.activeInHierarchy == false)//这个可以判断游戏物体是否激活
            {
                go.SetActive(true);
                return go;
            }
        }
        if(golist.Count >= maxAmount)
        {//池子已满
            GameObject.Destroy(golist[0]);
            golist.RemoveAt(0);
        }

        GameObject temp = GameObject.Instantiate(prefab) as GameObject;
        golist.Add(temp);
        return temp;
    }
}
