using UnityEngine;
using System.Collections;
using ArShooter.Managers;

namespace ArShooter.BehaviorComponents.Character
{
	[RequireComponent (typeof(Rigidbody))]
	[RequireComponent (typeof(EventManager))]
	public class MovementComponent : MonoBehaviour
	{
		Rigidbody rigidbody;
		EventManager eventManager;
		[SerializeField]
		public float acceleration;
		[SerializeField]
		Vector3 startDirection;
		// Use this for initialization
		void Awake ()
		{
			rigidbody = GetComponent<Rigidbody> ();
			eventManager = GetComponent<EventManager> ();
		}

		void OnEnable ()
		{
			startDirection = new Vector3 (Random.Range (-2, 2), 0, Random.Range (-2, 2));

		}


		public void Move ()
		{
			rigidbody.velocity = new Vector3 (startDirection.x * acceleration, rigidbody.velocity.y, startDirection.z * acceleration);

		}

		public void FixedUpdate ()
		{
			Move ();
		}
	}

}