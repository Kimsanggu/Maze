using UnityEngine;
using System.Collections;
public class RaycastTest : MonoBehaviour
{
	public GameObject AutoTargetImage;//자동타겟 이미지
	public GameObject SelectTargetImage;//지정타겟 이미지
	private GameObject Monster;
	public bool isTarget=false;
	public GameObject target;
	public Transform playerTr;
	private bool isAuto;
	private Transform AutoTr;
	private Vector3 vv =new Vector3(0,1,0);
	private bool isAutoTarget;
	void Awake()
	{
		isAutoTarget = false;
		isAuto = true;
		isTarget = false;
	
	}
	void Update()
	{
		CastBlock();
		if (!isTarget) {
			SetAutoTarget();
			AutoTarget();
		}
	}
	void SetAutoTarget(){
		AutoTr = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerCtrl> ().MinTr;
//		Debug.Log (AutoTr);
	}
	void AutoTarget(){
		Destroy(target);
		if (!isAutoTarget) {//isAutoTarget==false //오토타겟이 없을때 

			target = Instantiate (AutoTargetImage, AutoTr.position + vv * 0.2f, AutoTr.rotation)as GameObject;
			target.transform.Rotate (90, 0, 0);
			target.transform.parent = AutoTr.transform;
			isAutoTarget=true;
		}
		if((target.transform.position != AutoTr.transform.position)){//현재의 타겟위치와 오토타겟의 위치가 같이 않을때 

			target = Instantiate (AutoTargetImage, AutoTr.position + vv * 0.2f, AutoTr.rotation)as GameObject;
			target.transform.Rotate(90,0,0);
			target.transform.parent = AutoTr.transform;
//			Debug.Log("target position: "+target.transform.position.ToString()+" hit position : "+AutoTr.transform.position.ToString());
		}

	}
	private void CastBlock()
	{
		if (Input.GetMouseButtonDown(0))
		{


			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 1000.000f))
			{
				if (hit.collider.tag == "Monster")
				{
					//Debug.Log(hit.transform.tag);
					if(!isTarget){
						Destroy(target);
						isAutoTarget=false;
						target = Instantiate(SelectTargetImage,hit.transform.position+vv*0.2f,hit.transform.rotation)as GameObject;
						target.transform.Rotate(90,0,0);
						target.transform.parent = hit.transform;

						//Monster.gameObject.transform = hit.transform;
					}
					if(target.transform.position != hit.transform.position){
						Destroy(target);
						target = Instantiate(SelectTargetImage,hit.transform.position+vv*0.2f,hit.transform.rotation)as GameObject;
						target.transform.Rotate(90,0,0);
						target.transform.parent = hit.transform;
						Debug.Log("target position: "+target.transform.position.ToString()+" hit position : "+hit.transform.position.ToString());
					}
					isTarget=true;
					isAuto=false;
				}else if(hit.collider.tag=="Canvas"){
					Debug.Log(hit.ToString());
				}else if(hit.collider.tag =="AutoTargetImage"){
					Debug.Log(hit.ToString());
					Destroy(target);
					isTarget=false;
					isAuto=true;
				}else{
					Destroy(target);
					isTarget=false;
					isAuto=true;
				}
			}
		}
	}
}