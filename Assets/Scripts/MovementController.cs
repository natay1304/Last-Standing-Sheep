using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovementController : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _speed = 1f;
	[SerializeField] private float _dizziedTime = 1f;
	private float _dizzinessTime;

	private bool _targetReached;
	private Vector3 _targetPosition;

	private Transform _transform;
	private bool _dizzied;

	public void Move(Vector2 movement)
	{
		if (_dizzied)
			return;

		var direction = new Vector3(movement.x, 0, movement.y);
		var deltaAngle = Vector3.SignedAngle(_transform.forward, direction, Vector3.up);

		_transform.Rotate(0, deltaAngle * Time.deltaTime * 10f, 0);
		var forward = _transform.forward * _speed;
		_rigidbody.velocity = new Vector3(forward.x, _rigidbody.velocity.y, forward.z);  // _transform.forward * _speed;

		if (movement == Vector2.zero)
			_rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, 0f );
	}

	public void Hit(Vector3 force)
	{
		_dizzied = true;
		_dizzinessTime = 0;
		_rigidbody.AddForce(force * 1000f);
	}

	private void Awake()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		if (_dizzied)
		{
			_dizzinessTime += Time.deltaTime;
			if (_dizzinessTime > _dizziedTime)
				_dizzied = false;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.TryGetComponent<MovementController>(out var controller))
		{
			var offset = other.transform.position - _transform.position;
			if (Vector3.Angle(_rigidbody.velocity, offset) < 45) 
				controller.Hit(_rigidbody.velocity);
		}
	}
}