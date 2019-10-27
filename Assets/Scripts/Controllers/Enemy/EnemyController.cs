using UnityEngine;
using System.Collections;
using ArShooter.BehaviorComponents.Character;
using ArShooter.Managers;

namespace ArShooter.Controllers.Enemy
{
	
	[RequireComponent (typeof(EventManager))]
	public class EnemyController : MonoBehaviour
	{
		GameManager gameManager;
		EventManager eventManager;
		// Use this for initialization
		void Start ()
		{
			gameManager = ManagersContainer.Instance.GetManager<GameManager> ();
			eventManager = GetComponent<EventManager> ();
			eventManager.StartListening (Constants.DeadEvent, OnDead);
		}

		void OnDead (Hashtable eventParams)
		{
			gameManager.AddScore (10);
			gameObject.SetActive (false);

		}
		// Update is called once per frame
		void FixedUpdate ()
		{
//			movementComponent.Move(
		}
	}


}