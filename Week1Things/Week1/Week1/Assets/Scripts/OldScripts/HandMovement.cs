using UnityEngine;
using System.Collections;
using UnityEditor;

public class HandMovement : MonoBehaviour
{
	private CharacterController _controller;
	public float Speed = 100.0f;
	void Start()
	{ 
		_controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		_controller.Move(move * Time.deltaTime * Speed);
	}
}