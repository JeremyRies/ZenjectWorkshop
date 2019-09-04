using UnityEngine;
using Zenject;

public class PlayerInstaller : Installer<PlayerType,PlayerInstaller>
{
    private readonly PlayerType _type;

    public PlayerInstaller(PlayerType type)
    {
        _type = type;
    }
    public override void InstallBindings()
    {
        Debug.Log("Installing for player " + _type);
        Container.Bind<PlayerType>().FromInstance(_type).AsSingle();
        Container.BindInterfacesTo<InputProvider>().AsSingle();
        
        Container.BindInterfacesTo<PlayerModel>().AsSingle();
        Container.Instantiate<PlayerController>(); //.AsSingle().NonLazy();
    }
}