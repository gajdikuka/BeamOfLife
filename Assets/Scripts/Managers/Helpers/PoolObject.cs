using UnityEngine;
using System.Collections;

namespace ArShooter.Managers.Helpers
{
	public interface IPoolable
	{
		int Count { get; set; }

		string Name { get; }

		string PoolKey { get; set; }

		Transform MyTransform { get; }
	}

	public class PoolObject : MonoBehaviour, IPoolable
	{
		#region IPoolable implementation

		public Transform MyTransform { get { return this.transform; } }

		[SerializeField]
		int count;

		public int Count { get { return count; } set { count = value; } }

		[SerializeField]
		string poolKey;

		public string PoolKey { get { return poolKey; } set { poolKey = value; } }

		public string Name { get { return this.name; } }

		#endregion

	}
}

