using NUnit.Framework;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;


public class PongInstaller : MonoInstaller
{
    [SerializeField] private PlayerView _playerViewPrefab;

    public override void InstallBindings()
    {
        Debug.Log("Hello World");
        Container.Bind<PlayerView>().FromComponentInNewPrefab(_playerViewPrefab).AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();
    }
}