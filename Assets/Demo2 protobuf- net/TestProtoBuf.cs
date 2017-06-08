using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;

public class TestProtoBuf : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*下面是序列化，把对象转换为二进制数据

        User user = new User();
        user.ID = 100;
        user.UserName = "Ray";
        user.Password = "123456";
        user.Level = 100;
        user._UserType = User.UserType.master;
        //FileStream fs =  File.Create(Application.dataPath + "/user.bin");
        //Serializer.Serialize<User>(fs, user);//已经成为一个序列化
        //fs.Close();
        using (var fs = File.Create(Application.dataPath + "/user.bin"))
        {
            Serializer.Serialize<User>(fs, user);//已经成为一个序列化
        }
        */

        //下面是反序列化，把二进制数据转换为对象
        User user = null;

        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            Serializer.Deserialize<User>(fs);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
