using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField] private UpdateManager _updateManager;
	
	public override void InstallBindings()
	{
		Container.BindInterfacesTo<PlayerInput>();
		Container.BindInterfacesTo<UpdateManager>().FromInstance(_updateManager);

		Container.Instantiate<PlayerModel>();
	}
}

public interface IPlayerInput
{
	float GetMovement();
}
public class PlayerInput : IPlayerInput
{
	public float GetMovement()
	{
		return Input.GetAxis("Vertical");
	}
}

public interface IUpdateManager
{
	void SubscribeToUpdate(Action updateFunction);
}

public class UpdateManager : MonoBehaviour, IUpdateManager
{
	private List<Action> _updateFunctions;
	private void Update()
	{
		foreach (var updateFunction in _updateFunctions)
		{
			updateFunction.Invoke();
		}
	}

	public void SubscribeToUpdate(Action updateFunction)
	{
		_updateFunctions.Add(updateFunction);
	}
}

public interface PlayerPosition
{
	
}

public interface IPlayerModel
{
	IReadOnlyReactiveProperty<float> PlayerPosition { get; }
}

public class PlayerModel : IPlayerModel
{
	private readonly IPlayerInput _input;
	private readonly ReactiveProperty<float> _playerPosition = new ReactiveProperty<float>();

	public PlayerModel(IUpdateManager updateManager, IPlayerInput input)
	{
		_input = input;
		updateManager.SubscribeToUpdate(PlayerUpdate);
	}

	private void PlayerUpdate()
	{
		_playerPosition.Value += _input.GetMovement();
	}

	public IReadOnlyReactiveProperty<float> PlayerPosition
	{
		get { return _playerPosition; }
	}
}

public class PlayerController
{
	private readonly IPlayerModel _playerModel;

	public PlayerController(IPlayerModel playerModel, PlayerView view)
	{
		_playerModel = playerModel;
		_playerModel.PlayerPosition.Subscribe(pos => view.Position = pos);
	}
}

public class PlayerView : MonoBehaviour
{
	public float Position
	{
		set
		{
			transform.position += new Vector3(0,value,0);
		}
	}
}

public interface IReadOnlyReactiveProperty<T>
{
	T Value { get; }
	void Subscribe(Action<T> action);
}

public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>
{
	private T _value;
	private readonly List<Action<T>> _actions = new List<Action<T>>();

	public void Subscribe(Action<T> onNext)
	{
		_actions.Add(onNext);
	}

	public T Value
	{
		get { return _value; }
		set
		{
			_value = value;
			foreach (var action in _actions)
			{
				action.Invoke(_value);
			}
		}
	}
}