using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.Models;

namespace ArShooter.BehaviorComponents.Interfaces
{
	public interface IShootable
	{
		void Shoot (Vector3 target, GunModel gun);

		void LoadShoot (GunModel gun);
	}
}