using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour, ICounter
{
    private int _points;
    private Text _counterText;

    private void Start()
    {
        _counterText = GetComponent<Text>();
        SetText();
    }

    private void SetText()
    {
        _counterText.text = "Score: " + _points;
    }

    public void AddPoint()
    {
        _points++;
        SetText();
    }
}

public interface ICounter
{
    void AddPoint();
}