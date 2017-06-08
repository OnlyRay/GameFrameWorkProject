using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager {

    public bool isMute = false;

    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();
    //private static string savePath = Application.dataPath + "\\FrameWork\\Resources\\audiolist.txt";
    private static string audioTextPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    private const string audioTextPathMiddle = "audiolist";
    private const string audioTextPathPostfix = ".txt";
    public static string AudioTextPath
    {
        get
        {
            return audioTextPathPrefix + audioTextPathMiddle + audioTextPathPostfix;
        }
    }

    //public AudioManager()  因为注入的时候会调用它的其他构造方法，不能更改其默认的构造方法的调用
    //{
    //   LoadAudioClip();
    //}

    public void Init()
    {
        LoadAudioClip();
    }

    private  void LoadAudioClip()
    {
        audioClipDict = new Dictionary<string, AudioClip>();//清空字典
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathMiddle);//加载TextAsset类型的文件
        string[] lines = ta.text.Split('\n');
        foreach(string line in lines)
        {
            if(string.IsNullOrEmpty(line))
            {
                continue;
            }
            string[] keyvalue = line.Split(',');
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioClipDict.Add(key, value);
        }
    }

    //播放声音
    public void Play(string name)
    {
        if (isMute)//静音
        {
            return;
        }
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if(ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, Vector3.zero);
        }
    }

    public void Play(string name,Vector3 position)
    {
        if(isMute)//静音
        {
            return;
        }
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }
}
