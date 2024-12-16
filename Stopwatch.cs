using System;

public delegate void StopwatchEventHandler(string message);

public class Stopwatch
{
    private DateTime _startTime;
    private TimeSpan _elapsedTime;
    private bool _isRunning;

    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    public TimeSpan TimeElapsed => _isRunning ? DateTime.Now - _startTime + _elapsedTime : _elapsedTime;
    public bool IsRunning => _isRunning;

    public void Start()
    {
        if (!_isRunning)
        {
            _startTime = DateTime.Now;
            _isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
        }
    }

    public void Stop()
    {
        if (_isRunning)
        {
            _elapsedTime += DateTime.Now - _startTime;
            _isRunning = false;
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
    }

    public void Reset()
    {
        _isRunning = false;
        _elapsedTime = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }
}
