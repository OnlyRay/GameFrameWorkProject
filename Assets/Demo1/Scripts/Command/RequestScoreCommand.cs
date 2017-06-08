using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand {

    [Inject]
    public IScoreService scoreService
    {
        get;

        set;
    }
    [Inject]
    public ScoreModel scoreModel
    {
        get;

        set;
    }

    public override void Execute()
    {
        Retain();//这个是为了保存命令
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore,OnComolete);

        scoreService.RequestScore("http://xx/xxx/xxx");
    }

    public void OnComolete(IEvent evt)//Ievent存储传入的参数
    {
        Debug.Log("Request score complete."+evt.data);
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore,OnComolete);
        scoreModel.Score = (int)evt.data;//保存分数
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, evt.data);//这个会调用ScoreChange并把参数传过去
        
        Release();
    }
}
