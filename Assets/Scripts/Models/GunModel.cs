using UnityEngine;
using System.Collections;

namespace ArShooter.Models
{
	[CreateAssetMenu (fileName = "GunModel", menuName = "Create Gun", order = 1)]
	public class GunModel : ScriptableObject
	{
		public string name;
		public GameObject castEffect;
		public GameObject bullet;
		public float acceleration;
		public GameObject gunModel;
		public float power;
	}
}