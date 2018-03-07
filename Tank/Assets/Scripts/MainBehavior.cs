using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using machine;

/// <summary>
/// Main behavior.
/// </summary>
public class MainBehavior : MonoBehaviour
{
	private GameManager _gameManager;

	// Use this for initialization
	void Start ()
	{
		_gameManager = new GameManager ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_gameManager.Update ();
	}
}
