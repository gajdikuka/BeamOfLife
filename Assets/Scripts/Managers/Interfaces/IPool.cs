using UnityEngine;
using ArShooter.Managers.Helpers;
using System.Collections.Generic;

namespace ArShooter.Managers.Interfaces
{
	public interface IPool
	{
		GameObject Spawn (string key);

		GameObject Despawn (string key, string name, bool detach = false);

		void Init (List<GameObject> poolables, bool isAr=false);
	}
}