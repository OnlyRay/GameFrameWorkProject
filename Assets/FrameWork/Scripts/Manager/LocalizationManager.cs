using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager{

    //实现文件本地化的管理，也就是可以拥有中文版，英文版等
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    public const string Language = English;

    private Dictionary<string, string> dict;

    public LocalizationManager()
    {//解析文件
        dict = new Dictionary<string, string>();//初始化
        TextAsset ta = Resources.Load<TextAsset>(Language);//把Language解析成txt文件
        string[] lines = ta.text.Split('\n');
        foreach(string line in lines)
        {
            if(string.IsNullOrEmpty(line) == false)
            {//字符串不为空
                string[] keyvalues = line.Split('=');
                dict.Add(keyvalues[0], keyvalues[1]);
            }
        }
    }

    public void Init()
    {

    }


    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
