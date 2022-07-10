using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [Inject]
    IPooler _objectPooler;
    [SerializeField]
    private int _maxAmount;
    [SerializeField]
    private int _startAmount;
    [SerializeField]
    private float _minTimeBetweenSpawns;
    [SerializeField]
    private float _maxTimeBetweenSpawns;
    private float _timeBetweenSpawns;
    private Vector2 _screenBounds;

    private void Awake()
    {
        _objectPooler.PreparePool(_maxAmount);
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Start()
    {
        for (int i = 0; i < _startAmount; i++)
        {
            SpawnObject();
        }
        SetRandomTime();
    }

    private void Update()
    {
        _timeBetweenSpawns -= Time.deltaTime;
        if (_timeBetweenSpawns < 0)
        {
            SetRandomTime();
            SpawnObject();
        }
    }

    private void SetRandomTime()
    {
        _timeBetweenSpawns = Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns);
    }

    private void SpawnObject()
    {
        GameObject objectToSpawn = _objectPooler.GetObject();
        if (objectToSpawn)
        {
            objectToSpawn.transform.position = GetRandomPosition();
            objectToSpawn.SetActive(true);
        }
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(-_screenBounds.x, _screenBounds.x);
        float y = -_screenBounds.y;
        return new Vector2(x, y);
    }
}