using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Counter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMesh _text;
    [SerializeField] private float _delay;

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

    private void Start()
    {
        _text.text = "0";
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_delay);

        while (_count++ < int.MaxValue)
        {
            DisplayCount();
            yield return wait;
        }
    }

    private void DisplayCount()
    {
        _text.text = _count.ToString();
    }    
}
