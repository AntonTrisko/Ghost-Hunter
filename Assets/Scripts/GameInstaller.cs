using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private Ghost _ghost;
    [SerializeField]
    private Counter _counter;

    public override void InstallBindings()
    {
        Container.BindFactory<Ghost, Factory>()
              .FromComponentInNewPrefab(_ghost)
              .WithGameObjectName("Ghost")
              .UnderTransformGroup("Ghosts");
        Container.Bind<IPooler>().To<ObjectPooler>().AsSingle();
        Container.Bind<ICounter>().To<Counter>().FromInstance(_counter).AsSingle();
    }
}