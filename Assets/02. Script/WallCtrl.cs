using UnityEngine;
using System.Collections;

public class WallCtrl : MonoBehaviour {
	public GameObject SparkEffect;
	private Transform thistr;
	// Use this for initialization
	void Start(){
		thistr = GetComponent<Transform> ();
	}
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Bullet") {
			Object obj = Instantiate(SparkEffect,coll.transform.position,coll.transform.rotation);
			Destroy(obj,2f);
			Destroy (coll.gameObject);
		} else if(coll.gameObject.tag=="Player") {
			Transform tr = coll.gameObject.GetComponent<Transform>();
			Rigidbody rd = coll.gameObject.GetComponent<Rigidbody>();
			Vector3 V3 = tr.position - thistr.position;
			rd.AddForce(V3);

		}
	}
	void Update(){

	}
}
