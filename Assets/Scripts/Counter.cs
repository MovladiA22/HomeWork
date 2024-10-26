using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Counter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _delay;
    [SerializeField] private CounterRenderer _counterRenderer;

    private Coroutine _coroutine;
    private bool _isPaused = false;
    private int _count = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCount();
    }

    private void StartCount()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Count());
        }
        else if (_isPaused)
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

        while (_count++ < int.MaxValue)
        {
            _counterRenderer.DisplayCount(_count);
            yield return wait;
        }
    }    
}
