using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

[ProtoContract]
public class User  {
    [ProtoMember(1)]//这个是tag 是标识，只有一个，不可重复,根据tag读取属性
    public int ID
    {
        get;
        set;
    }
    [ProtoMember(2)]
    public string UserName
    {
        get;
        set;
    }
    [ProtoMember(3)]
    public string Password
    {
        get;
        set;
    }
    [ProtoMember(4)]
    public int Level
    {
        get;
        set;
    }
    [ProtoMember(5)]
    public UserType _UserType
    {
        get;
        set;
    }
    public enum UserType
    {
        master,
        warrior
    }
}
