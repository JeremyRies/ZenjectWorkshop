using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class PongInstaller : MonoInstaller
{
    [SerializeField] private PlayerView _playerViewPrefab;
    [SerializeField] private UpdateManager _updateManager;
    [SerializeField] private PlayerConfig _playerConf;
    public override void InstallBindings()
    {
        Container.Bind<PlayerView>().FromComponentInNewPrefab(_playerViewPrefab).AsTransient();
        Container.BindInterfacesTo<UpdateManager>().FromInstance(_updateManager).AsSingle();
        Container.BindInterfacesTo<PlayerConfig>().FromInstance(_playerConf);

        var playerLeftContainer = Container.CreateSubContainer();
        PlayerInstaller.Install(playerLeftContainer,PlayerType.left);

        var playerRightContainer = Container.CreateSubContainer();
        PlayerInstaller.Install(playerRightContainer,PlayerType.right);
        
//        Container.Bind<PlayerType>().FromInstance(PlayerType.right).AsSingle();
//        Container.BindInterfacesTo<InputProvider>().AsSingle();
//        
//        Container.BindInterfacesTo<PlayerModel>().AsSingle();
//        Container.Bind<PlayerController>().AsSingle().NonLazy();
    }
}