using UnityEngine;
using Zenject;

public class PongInstaller : MonoInstaller<PongInstaller>
{
    [SerializeField] private PlayerView _playerViewPrefab;
    [SerializeField] private UpdateManager _updateManager;
    [SerializeField] private PlayerConfig _playerConfig;

    public override void InstallBindings()
    {
        Container.Bind<PlayerView>().FromComponentInNewPrefab(_playerViewPrefab).AsTransient();
        Container.BindInterfacesTo<UpdateManager>().FromInstance(_updateManager).AsSingle();
        Container.BindInterfacesTo<PlayerConfig>().FromInstance(_playerConfig).AsSingle();


        var leftContainer = Container.CreateSubContainer();
        PlayerInstaller.Install(leftContainer, PlayerType.Left);
        
        var rightContainer = Container.CreateSubContainer();
        PlayerInstaller.Install(rightContainer, PlayerType.Right);
    }
}