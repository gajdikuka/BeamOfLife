using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.BehaviorComponents.Interfaces;
using ArShooter.Models;
using ArShooter.Managers;

namespace ArShooter.BehaviorComponents
{

	public class NormalShootComponent : MonoBehaviour, IShootable
	{
		PoolManager poolManager;
		[SerializeField]
		Transform hand;
		GameObject castEffect;

		#region IShootable implementation

		public void LoadShoot (GunModel gun)
		{
			castEffect = poolManager.Spawn (gun.castEffect.name);
			castEffect.transform.position = hand.position; 
		}


		public void Shoot (Vector3 target, GunModel gun)
		{
			if (castEffect != null) {
				castEffect.SetActive (false);
			}
			GameObject bullet = poolManager.Spawn (gun.bullet.name);
			BulletController bulletController = bullet.GetComponent<BulletController> ();
			bulletController.Init (gun);
//			Vector3 cameraPos = Camera.main.transform.position;
			bullet.transform.rotation = Camera.main.transform.rotation;
			bullet.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z );
//			hand.transform.rotation = Quaternion.LookRotation (ray.direction - hand.transform.position, Vector3.up);
			bulletController.rigidbody.velocity = target * gun.acceleration;

		}

		#endregion

		void Update ()
		{
			if (castEffect != null) {
				castEffect.transform.position = hand.transform.position;
			}
		}
		// Use this for initialization
		void Start ()
		{
			poolManager = ManagersContainer.Instance.GetManager<PoolManager> ();
		
		}

	}
}