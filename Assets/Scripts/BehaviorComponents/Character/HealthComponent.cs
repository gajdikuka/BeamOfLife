using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.Managers;

[RequireComponent (typeof(EventManager))]
public class HealthComponent : MonoBehaviour
{

	[SerializeField]
	float currentAmount, maxAmount;

	EventManager eventManager;
	// Use this for initialization
	void Awake ()
	{
		eventManager = GetComponent<EventManager> ();
		currentAmount = maxAmount;
	}

	void Start ()
	{
		eventManager.StartListening (Constants.RespawnEvent, OnRespawned);
		eventManager.StartListening (Constants.DamageEvent, OnDamage);
	}

	void OnRespawned (Hashtable eventParams)
	{
		currentAmount = maxAmount;
	}

	void OnDamage(Hashtable eventParams){
		float amount = (float) eventParams [Constants.NewValueParam1];
		currentAmount -= amount;
		if (currentAmount <= 0) {
			eventManager.TriggerEvent (Constants.DeadEvent);
			gameObject.SetActive (false);
		}

	}


}
