using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField] private MovementController _movementController;
	private Transform _grass;
	private GameZone _gameZone;

	private bool _targetReached;
	private Vector3 _targetPosition;
	private float _reachDistance = 0.2f;

	private void Update()
	{
		TargetReached();
		if (_targetReached)
		{
			_targetPosition = GetNextPosition();
		}
		else
		{
			var movement = (_targetPosition - transform.position).normalized;
			_movementController.Move(new Vector2(movement.x, movement.z));
		}

		if (transform.position.y < _grass.position.y - 5f)
			Destroy(gameObject);
	}

	public void Initialize(GameZone gameZone, Transform grass)
	{
		_gameZone = gameZone;
		_grass = grass;
		_targetPosition = GetNextPosition();
	}

	private Vector3 GetNextPosition()
	{
		var position = Random.insideUnitCircle * _gameZone.Size;
		_targetReached = false;
		return new Vector3(position.x, 0f, position.y);
	}

	private void TargetReached()
	{
		var delta = _targetPosition - transform.position;
		var direction = delta.normalized;
		if (delta.magnitude < _reachDistance)
		{
			_targetReached = true;
			return;
		}
	}
}
