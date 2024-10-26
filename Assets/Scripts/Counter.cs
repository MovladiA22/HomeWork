using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Counter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _delay;

    public event Action Counting;
    private Coroutine _coroutine;
    private bool _isPaused = true;
    private int _count = 0;

    public int CurrentCount => _count;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCount();
    }

    private void StartCount()
    {
        if (_isPaused)
        {
            _coroutine = StartCoroutine(Count());
            _isPaused = false;
        }
        else
        {
            StopCoroutine(_coroutine);
            _isPaused = true;
        }

    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_delay);

        while (_count < int.MaxValue)
        {
            Counting?.Invoke();
            _count++;
            yield return wait;
        }
    }    
}
