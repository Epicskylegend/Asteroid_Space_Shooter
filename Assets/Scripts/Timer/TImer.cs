using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer
{

    public event Action OnTimerDone;

    public float duration
    {
        get
        {
            return _duration;
        }
        set
        {
            _endTime = _startTime + value;
            _duration = value;

        }
    }

    float _duration = 0;
    float _endTime = 0;
    float _startTime = 0;
    bool _running = false;
    public Timer(float duration)
    {
        this.duration = duration;
    }
    public void ResetTimer()
    {
        _running = true;
        _startTime = Time.time;
        _endTime = _startTime + _duration;
    }


    public void ResetAction()
    {
        OnTimerDone = delegate { };
    }

    public void Tick()
    {
        if (_running && IsDone())
        {
            _running = false;
            OnTimerDone?.Invoke();
        }
    }

    public bool IsDone()
    {
        return Time.time >= _endTime;
    }

    public float GetTimeLeft()
    {
        return Mathf.Max(0, _endTime - Time.time);
    }

    public float GetTimeElapsed()
    {
        return Time.time - _startTime;
    }

}
