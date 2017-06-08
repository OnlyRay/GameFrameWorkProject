using strange.extensions.context.impl;
using strange.extensions.context.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Context : MVCSContext {
    public Demo1Context(MonoBehaviour view) : base(view) { }
	protected override void mapBindings() //用来绑定对应映射
    {
        //manager
        injectionBinder.Bind<AudioManager>().To<AudioManager>().ToSingleton();//在任何一个view类里面都能调用
        //model
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();//实例前者，后者构造
        //service
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();//表示只在工程生成一次
        //command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();
        //mediator
        mediationBinder.Bind<CubeView>().To<CubeMediator>();//完成View和Mediator的绑定


        //创建一个startcommand命令进行初始化工作,绑定并触发
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
