using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangeAnim : MonoBehaviour
{
    private float _currentScale;
    [SerializeField] private float TargetScale = 1.4f;
    [SerializeField] private float InitScale = 1f;
    [SerializeField] private int FramesCount = 100;
    [SerializeField] private float AnimationTimeSeconds = 0.5f;
    private float _deltaTime;
    private float _dx;
    private bool _upScale = true;
    private bool _endAnim = false;

    public void Start()
    {   
        _deltaTime = AnimationTimeSeconds/FramesCount;
        _dx = (TargetScale - InitScale)/FramesCount;
        _currentScale = InitScale;
    }

    private IEnumerator Breath()
    {
        while (!_endAnim)
        {
            while (_upScale)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    _upScale = false;
                    _currentScale = TargetScale;
                }
                transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }

            while (!_upScale)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    _upScale = true;
                    _currentScale = InitScale;
                    _endAnim = true;
                }
                transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
        _endAnim = false;
        StopCoroutine(Breath());
    }

    //Hace la animación ;D
    public void DoIt()
    {
        StartCoroutine(Breath());
    }
    
}
