using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command {
    //开始命令,进行初始化操作

    [Inject]
    public AudioManager audioManager
    {
        get;

        set;
    }

    //当命令被执行的时候，默认调用execute方法
    public override void Execute()
    {
        audioManager.Init();
        PoolManager.Instance.Init();
        LocalizationManager.Instance.Init();
    }


}
