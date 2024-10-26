using UnityEngine;

public class CounterRenderer : MonoBehaviour
{
    [SerializeField] private TextMesh _text;

    public void DisplayCount(int count)
    {
        _text.text = count.ToString();
    }

    private void Start()
    {
        _text.text = "0";
    }
}
