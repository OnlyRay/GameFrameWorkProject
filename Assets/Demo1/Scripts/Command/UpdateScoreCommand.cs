using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreCommand : EventCommand {
    [Inject]
    public ScoreModel scoreModel { get; set; }

    [Inject]
    public IScoreService scoreService { get; set; }
    public override void Execute()//更新分数
    {
        //通过scoremodel来获取分数
        scoreModel.Score++;
        //更新到Service
        scoreService.UpdateScore("http://**/***/***",scoreModel.Score);
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, scoreModel.Score);  
    }

}
