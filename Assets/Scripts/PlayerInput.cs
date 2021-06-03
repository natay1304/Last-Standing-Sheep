using System;
using EasyJoystick;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public event Action OnPlayerFallen;
	[SerializeField] private Joystick _joystickPrefab;
	[SerializeField] private MovementController _movementController;
	[SerializeField] private Transform _grass;
	
	private float _targetAngle = 0;
	private bool _gameOver = false;

	private void Update()
	{
		
		
		float xMovement = _joystickPrefab.Horizontal();
		float zMovement = _joystickPrefab.Vertical();
		Vector2 targetPosition = new Vector2(xMovement, zMovement);
		_movementController.Move(targetPosition);
		
		if(_gameOver)
			return;
		CheckPlayerFalling();
	}

	public void CheckPlayerFalling()
	{
		if (transform.position.y < _grass.position.y - 2f)
		{
			OnPlayerFallen?.Invoke();
			_gameOver = true;
		}
	}
}