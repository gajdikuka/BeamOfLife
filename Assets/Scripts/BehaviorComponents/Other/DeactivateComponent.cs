using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArShooter.BehaviorComponents
{
	
	public class DeactivateComponent : MonoBehaviour
	{
		[SerializeField]
		float time;
		// Use this for initialization
		void OnEnable ()
		{
			StartCoroutine (Deactivate ());
		}

		IEnumerator Deactivate ()
		{
			yield return new WaitForSeconds (time);
			gameObject.SetActive (false);
		}
	}
}