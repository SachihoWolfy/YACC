using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    public static bool _isReplaying;
    public static bool _isRecording;
    private PlayerMovement _PlayerMovement;
    private Command _buttonA, _buttonD, _buttonW;

    private void Start()
    {
        if (_invoker == null) { _invoker = gameObject.AddComponent<Invoker>(); }
        if (_PlayerMovement == null) { _PlayerMovement = gameObject.AddComponent<PlayerMovement>(); }

        _buttonA = new TurnLeft(_PlayerMovement);
        _buttonD = new TurnRight(_PlayerMovement);
        _buttonW = new ToggleTurbo(_PlayerMovement);
    }

    private void FixedUpdate()
    {
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _invoker.ExecuteCommand(_buttonA);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _invoker.ExecuteCommand(_buttonD);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                _invoker.ExecuteCommand(_buttonW);
            }
        }
    }
    public void StartRecording()
    {
        if(_PlayerMovement == null) { _PlayerMovement = FindObjectOfType<PlayerMovement>(); }
        if (_PlayerMovement == null) { _PlayerMovement = gameObject.AddComponent<PlayerMovement>(); }
        if (_invoker == null) { _invoker = gameObject.AddComponent<Invoker>(); }
        _isReplaying = false;
        _isRecording = true;
        _invoker.Record();
    }
    public void StopRecording()
    {
        _isRecording = false;
    }
    public void StartReplay()
    {
        if (_invoker == null) { _invoker = gameObject.AddComponent<Invoker>(); }
        if (_PlayerMovement == null) { _PlayerMovement = gameObject.AddComponent<PlayerMovement>(); }
        _isRecording = false;
        _isReplaying = true;
        _invoker.Replay();
    }
}
