using System.Collections.Generic;
using ModestTree.Util;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class PongInstaller : MonoInstaller<PongInstaller>
    {
        [SerializeField] private PlayerView _playerViewPrefab;

        public override void InstallBindings()
        {
            Debug.Log("Hello, World!");
            Container.Bind<PlayerView>().FromComponentInNewPrefab(_playerViewPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();
        }
    }
}