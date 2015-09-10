using UnityEngine;
using System.Collections;

public class BarrelCtrl : MonoBehaviour {
	public GameObject expEffect;
	private Transform tr;

	public int hitCount =0;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
	}
	void OnCollisionEnter(Collision coll){
		if (coll.collider.tag == "Bullet") {
			Destroy(coll.gameObject);
			if(++hitCount>=3){
				StartCoroutine(this.ExplosionBarrel());
			}
		}
	}
	IEnumerator ExplosionBarrel(){
		Instantiate (expEffect, tr.position, Quaternion.identity);

		Collider[] colls = Physics.OverlapSphere (tr.position, 10.0f);

		foreach (Collider coll in colls) {
			if(coll.GetComponent<Rigidbody>() !=null){
				coll.GetComponent<Rigidbody>().mass=1.0f;
				coll.GetComponent<Rigidbody>().AddExplosionForce(800.0f,tr.position,10.0f,300.0f);
				if(coll.gameObject.tag=="Player"){
					Debug.Log(coll);
					coll.GetComponentInChildren<Character1>().Hp-=10;
				}
			}
		}
		Destroy (gameObject, 5.0f);
		yield return null;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
