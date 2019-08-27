using UnityEngine;
using Zenject;

public class PongInstaller : MonoInstaller<PongInstaller>
{
    [SerializeField] private PlayerView _playerViewPrefab;
    [SerializeField] private UpdateManager _updateManager;
    [SerializeField] private PlayerConfig _playerConfig;

    public override void InstallBindings()
    {
        Container.Bind<PlayerView>().FromComponentInNewPrefab(_playerViewPrefab).AsSingle();

        Container.BindInterfacesTo<UpdateManager>().FromInstance(_updateManager).AsSingle();
        Container.BindInterfacesTo<PlayerConfig>().FromInstance(_playerConfig).AsSingle();

        Container.BindInterfacesTo<InputProvider>().AsSingle();

        Container.BindInterfacesTo<PlayerModel>().AsSingle();
        Container.Bind<PlayerController>().AsSingle().NonLazy();
    }
}