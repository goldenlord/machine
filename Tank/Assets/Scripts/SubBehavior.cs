using UnityEngine;
using System.Collections;

public class SubBehaviour : MonoBehaviour
{
	public void _StartCoroutine (IEnumerator coroutine)
	{
		StartCoroutine (coroutine);
	}
}