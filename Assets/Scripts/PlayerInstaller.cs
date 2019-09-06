using Zenject;

public class PlayerInstaller : Installer<PlayerType, PlayerInstaller>
{
    private readonly PlayerType _playerType;

    public PlayerInstaller(PlayerType playerType)
    {
        _playerType = playerType;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(_playerType).AsSingle();

        Container.BindInterfacesTo<InputProvider>().AsSingle();
        Container.BindInterfacesTo<PlayerModel>().AsSingle();
        Container.Bind<PlayerController>().AsSingle().NonLazy();
        Container.Instantiate<PlayerController>();
    }
}