using UnityEngine;

public class CounterRenderer : MonoBehaviour
{
    [SerializeField] private TextMesh _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = "0";
    }

    private void OnEnable()
    {
        _counter.Counting += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.Counting -= DisplayCount;
    }

    private void DisplayCount()
    {
        _text.text = _counter.CurrentCount.ToString();
    }
}
