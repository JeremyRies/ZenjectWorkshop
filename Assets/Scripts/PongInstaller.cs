﻿using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;


public class PongInstaller : MonoInstaller
{
    [SerializeField] private PlayerView _playerViewPrefab;
    [SerializeField] private UpdateManager _updateManager;
    [SerializeField] private PlayerConfig _playerConf;

    public override void InstallBindings()
    {
        Debug.Log("Hello World");
        Container.Bind<PlayerView>().FromComponentInNewPrefab(_playerViewPrefab).AsSingle();
        Container.BindInterfacesTo<PlayerModel>().AsSingle();
        Container.Bind<PlayerController>().AsSingle().NonLazy();

        Container.BindInterfacesTo<UpdateManager>().FromInstance(_updateManager).AsSingle();
        Container.BindInterfacesTo<InputProvider>().AsSingle();

        Container.BindInterfacesTo<PlayerConfig>().FromInstance(_playerConf);
    }
}