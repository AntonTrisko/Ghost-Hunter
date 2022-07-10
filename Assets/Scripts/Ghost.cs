using UnityEngine;
using Zenject;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [Inject]
    private ICounter _counter;
    private Vector2 _screenBounds;

    private void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnMouseDown()
    {
        _counter.AddPoint();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (_screenBounds.y < transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}