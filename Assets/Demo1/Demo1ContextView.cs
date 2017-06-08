using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1ContextView : ContextView {//Root,启动MVCSContext
    void Awake()
    {
        this.context = new Demo1Context(this);//也就是创建一个Demo1Context对象，用来启动UI框架
        
    }
	
}
