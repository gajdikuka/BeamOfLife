using UnityEngine;
using System.Collections;
using System.Diagnostics;
using ArShooter.Managers;

namespace ArShooter.Demos
{
	

	public class TestPoolManager : MonoBehaviour
	{
		

		PoolManager poolManager;

		// Use this for initialization
		void Start ()
		{
			poolManager = FindObjectOfType<PoolManager> (); //IPool
//		StartCoroutine (GetCube ());
		}

		IEnumerator GetCube ()
		{
			yield return new WaitForSeconds (5f);
			GameObject cubeGo = poolManager.Spawn ("Cube");
			StartCoroutine (GetCube ());
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetMouseButtonUp (0)) {
				var stopwatch = new Stopwatch ();
				stopwatch.Start ();
				GameObject cubeGo = poolManager.Spawn ("Cube");
				stopwatch.Stop ();
				UnityEngine.Debug.Log (stopwatch.Elapsed.TotalMilliseconds);
			}
			if (Input.GetMouseButtonUp (1)) {
				GameObject cubeGo = poolManager.Spawn ("Cube");
			}
		}
	}

}