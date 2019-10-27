using UnityEngine;
using System.Collections;
using ArShooter.BehaviorComponents.Character;
using ArShooter.Models;

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HitComponent))]
public class BulletController : MonoBehaviour
{
	[HideInInspector]
	public Rigidbody rigidbody;
	[HideInInspector]
	public HitComponent hitComponent;
	[HideInInspector]
	// Use this for initialization
	void Awake ()
	{
		rigidbody = GetComponent <Rigidbody> ();
		hitComponent = GetComponent<HitComponent> ();
	}
	public void Init(GunModel model){
		hitComponent.power = model.power;
	}

}

