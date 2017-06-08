using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;
using System.IO;

public class AudioWindowEditor : EditorWindow {
    //加入一个特性
    [MenuItem("Manager/AudioManager")]//必须有子菜单
	static void CreatWindow()
    {
        //Rect rect = new Rect(0, 0, 500, 500);//前两个参数表示的是距离左上角的位置，后面两个表示长和宽
        //AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor), rect, true) as AudioWindowEditor;
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");//这个是可以改变窗口的大小的
        window.Show();
    }

    //窗口绘制

    //private string text;
    private string audioName;
    private string audioPath;
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();

    void OnGUI()
    {
        //text = EditorGUILayout.TextField("输入文字",text);//输入的文字保存到text里(有标签)
        //GUILayout.TextField("输入文字2");//这个是直接一个输入框
        //下面是遍历所有的音效
        //标题栏
        EditorGUILayout.BeginHorizontal();//水平布局
        EditorGUILayout.LabelField("音效名称");
        EditorGUILayout.LabelField("音效路径");
        EditorGUILayout.LabelField("操作");
        EditorGUILayout.EndHorizontal();
        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key,out value);
            EditorGUILayout.BeginHorizontal();//水平布局
            EditorGUILayout.LabelField(key);
            EditorGUILayout.LabelField(value);
            if(GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                SaveAudioList();
                return;
            }
            EditorGUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("音效名字", audioName);
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
        if(GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(audioPath);
            if(o == null)
            {
                Debug.LogWarning("音效不存在" + audioPath + "添加不成功");
                audioPath = "";
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("音效已经存在,请修改");
                }
                else
                {
                    audioDict.Add(audioName, audioPath);
                    SaveAudioList();
                }
            }
        }
    }

    
    //窗口面板被更新的时候调用
    void OnInspectorUpdate()
    {
        //Debug.Log("Update");
        LoadAudioList();
    }

    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            sb.Append(key + "," + value + "\n");
        } 
        File.WriteAllText(AudioManager.AudioTextPath, sb.ToString());
        //File.AppendAllText(savePath, sb.ToString());
    }
    private void LoadAudioList()
    {
        audioDict = new Dictionary<string, string>();
        if(File.Exists(AudioManager.AudioTextPath) == false)
        {
            //文件不存在
            return;
        }
        string[] lines = File.ReadAllLines(AudioManager.AudioTextPath);
        foreach(string line in lines)
        {
            if(string.IsNullOrEmpty(line))
            { 
                //空字符串
                continue;
            }
            string[] keyvalue = line.Split(',');
            audioDict.Add(keyvalue[0], keyvalue[1]);
        }
    }
}
