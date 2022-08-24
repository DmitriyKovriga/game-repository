using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEvent _onComplite;
    [SerializeField] private UnityEvent _onStart;

    private SpriteRenderer _renderer;
    private float _secondsPerFrame;
    private int _currentSpritIndexe;
    private float _nextFrameTime;

    private bool _isPlaying = false;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _secondsPerFrame = 1f / _frameRate; // 1 секунда деленная на фрейм рейт, будет секунда на фрейм
        _nextFrameTime = Time.time + _secondsPerFrame;
    }

    private void Update()
    {
        if (_nextFrameTime > Time.time || !_isPlaying) return; //если не наступило время смены кадра и бул исплеинг фалсе, то мы делаем return и обрываем итерацию
        if (_currentSpritIndexe == _sprites.Length)
        {
            if (_loop)
            {
                _currentSpritIndexe = 0;
            } else
            {
                _isPlaying = false;
                _onComplite?.Invoke();
                _currentSpritIndexe = 0;
                return;
            }

        }
        if (_currentSpritIndexe == 0)
        {
            _onStart?.Invoke();
        }
        Debug.Log("Анимация вспышки от выстрела " + gameObject.name);
        _renderer.sprite = _sprites[_currentSpritIndexe]; //назначаем новый кадр
        _nextFrameTime += _secondsPerFrame; //обновляем время для следующего апдейта кадра
        _currentSpritIndexe++; //переставляем индекс спрайта
    }

    public void ChengeToNone()
    {
        _renderer.sprite = null;
    }

    public void Play()
    {
        _isPlaying = true;
    }

    public void StopPlay()
    {
        _isPlaying = false;
    }

}
