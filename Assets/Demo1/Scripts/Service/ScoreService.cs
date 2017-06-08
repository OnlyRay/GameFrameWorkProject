using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher
    {
        get;

        set;
    }

    public void OnReceiveScore()
    {
        int score = UnityEngine.Random.Range(0, 100);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore,score);
    }

    public void RequestScore(string url)
    { 
        //模拟
        Debug.Log("Request score from url:"+url);
        OnReceiveScore();
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update score to url:" + url + "  new score" + score);
    }
}
