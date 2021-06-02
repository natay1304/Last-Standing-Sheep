using System.Collections;
using System.Collections.Generic;
using EasyJoystick;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private Joystick _joystickPrefab;
	[SerializeField] private MovementController _movementController;
	[SerializeField] private Transform _grass;

	private bool _playerFalled;
	private float _targetAngle = 0;

	public bool PlayerFalled => _playerFalled;

	private void Update()
	{
		float xMovement = _joystickPrefab.Horizontal();
		float zMovement = _joystickPrefab.Vertical();
		Vector2 targetPosition = new Vector2(xMovement, zMovement);

		_movementController.Move(targetPosition);
	}

	public void CheckPlayerFalling()
	{
		if (transform.position.y < _grass.position.y)
		{
			transform.position = new Vector3(transform.position.x, _grass.position.y - 2f, transform.position.z);
			_playerFalled = true;
		}
		else
			_playerFalled = false;
	}
}