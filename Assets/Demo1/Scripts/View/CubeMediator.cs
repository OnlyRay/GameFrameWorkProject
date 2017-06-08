using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : Mediator { 
    //加个注入调用View
    [Inject]
    public CubeView cubeView
    {
        get;

        set;
    }
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]//全局的dispatcher
    public IEventDispatcher dispatcher
    {
        get;

        set;
    }

    public override void OnRegister()
    {
        cubeView.Init();
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, OnScoreChaged);
        //通过dispatcher发送请求分数的命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown, OnClickDown);
    }

    public override void OnRemove()//当View销毁的时候调用
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChaged);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);
        //通过CubeView来调用CubeMediator的OnClickDown来分开，再用Mediator用命令来更新分数
    }

    public void OnScoreChaged(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);//更新分数    
    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);//发出更新分数的命令
    }
}
