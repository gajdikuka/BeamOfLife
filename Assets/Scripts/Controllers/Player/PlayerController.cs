using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.BehaviorComponents.Interfaces;
using ArShooter.Models;
using ArShooter.Managers;
using ArShooter.Managers.Helpers;
using ArShooter.BehaviorComponents;

namespace ArShooter.Controllers.Player
{
	
	[RequireComponent (typeof(IShootable))]
	public class PlayerController : MonoBehaviour, IPoolFeeder
	{
		PoolManager poolManager;
		[SerializeField]
		GunModel gun;
		IShootable shootingComponent;
		Animator animator;
		CharacterStateComponent characterStateComponent;
		[SerializeField]
		Transform cursor;

		// Use this for initialization
		void Awake ()
		{
			shootingComponent = GetComponent<IShootable> ();
			characterStateComponent = GetComponent<CharacterStateComponent> ();
			animator = GetComponent<Animator> ();
		}

		void Start ()
		{
			poolManager = ManagersContainer.Instance.GetManager<PoolManager>();
			FeedPoolManager ();
			Debug.Log ("InitGunEffects");
		}

		public void FeedPoolManager ()
		{
			List<GameObject> poolables = new List<GameObject> (){ gun.bullet, gun.castEffect };
			poolManager.Init (poolables);
		}
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetMouseButtonUp (0) && characterStateComponent.currentState == CharacterState.CastAttack) {
				characterStateComponent.ChangeState (CharacterState.Attack);
				animator.SetTrigger ("Attack");
				Ray ray = Camera.main.ScreenPointToRay (cursor.transform.position);
				Vector3 shootPos = new Vector3 (ray.direction.x, ray.direction.y, ray.direction.z);
				shootingComponent.Shoot (shootPos, gun);
				characterStateComponent.ChangeState (CharacterState.Idle);
			}
			if (Input.GetMouseButtonDown (0) && characterStateComponent.currentState == CharacterState.Idle) {
				animator.SetBool ("Aiming", true);
				characterStateComponent.ChangeState (CharacterState.CastAttack);
				shootingComponent.LoadShoot (gun);
			}
		
		}
	}
}