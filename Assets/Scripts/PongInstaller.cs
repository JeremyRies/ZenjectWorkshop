using UnityEngine;
using Zenject;

public class PongInstaller : MonoInstaller
{
	[SerializeField] private UpdateManager _updateManager;
	[SerializeField] private PlayerView _playerViewPrefab;
	
	public override void InstallBindings()
	{
		Debug.Log("test");
		Container.BindInterfacesTo<PlayerInput>().AsSingle();
		Container.BindInterfacesTo<UpdateManager>().FromInstance(_updateManager);

		Container.BindInterfacesTo<PlayerModel>().AsSingle();

		Container.Bind<PlayerView>().FromComponentInNewPrefab(_playerViewPrefab).AsSingle();
		Container.Bind<PlayerController>().AsSingle().NonLazy();
	}
}