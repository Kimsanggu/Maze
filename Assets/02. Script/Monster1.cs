using UnityEngine;
using System.Collections;
using Name_Maze;
public class Monster1 : MonoBehaviour {
	public MonsterState monsterState=MonsterState.idle;
	private Transform monsterTr;//몬스터위치
	private Transform playerTr;//플레이어위치
	private NavMeshAgent nvAgent;//NavMeshAgent 컴포넌트
	public float hp =100.0f;
	public float ad = 10.0f;
	public float traceDist = 10.0f;
	public float attackDist = 2.0f;
	private bool isDie = false;

	private Animator _animator;
	// Use this for initialization
	void Awake(){

	}
	void Start () {
		monsterTr = this.GetComponent<Transform> ();

		playerTr = GameObject.FindWithTag ("Player").GetComponent<Transform> ();

		nvAgent = this.GetComponent<NavMeshAgent> ();

		_animator = GetComponent<Animator> ();

		StartCoroutine (this.CheckMonsterState ());

		StartCoroutine (this.MonsterAction ());
	}
	void FixedUpdate(){

		}
	
	// Update is called once per frame
	void Update () {
		nvAgent.destination = playerTr.position;
//		Debug.Log (monsterState);
	}
	IEnumerator CheckMonsterState(){
		while (!isDie) {
			yield return new WaitForSeconds (0.2f);
			float dist = Vector3.Distance (playerTr.position, monsterTr.position);

			if (dist <= attackDist) {
				monsterState = MonsterState.attack;
			} else if (dist <= traceDist) {
				monsterState = MonsterState.trace;
			}else{
				monsterState = MonsterState.idle;
			}

		}
	}
	IEnumerator MonsterAction(){
		while(!isDie){
			switch(monsterState){
			case MonsterState.idle:
//				Debug.Log("monster idle");
				nvAgent.Stop();
				_animator.SetBool("IsTrace",false);
				_animator.SetBool("IsAttack",false);

				break;
			case MonsterState.trace:
//				Debug.Log("monster trace");
				//nvAgent.Resume();
				nvAgent.destination=playerTr.position;
				_animator.SetBool("IsTrace",true);
				_animator.SetBool("IsAttack",false);

				break;
			case MonsterState.attack:
				Debug.Log("monster attack");
				_animator.SetBool("IsAttack",true);
				_animator.SetBool("IsTrace",false);
				break;
			case MonsterState.die:
				Debug.Log("monster die");
				_animator.SetBool("IsDie",true);
				nvAgent.Stop();

				break;
			case MonsterState.gothit:
				Debug.Log("monster gothit");
				_animator.SetBool("IsAttack",false);
				_animator.SetBool("IsTrace",false);
				break;
			}
			yield return null;
		}
	}
	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.tag=="Bullet"){
			hp-=coll.gameObject.GetComponent<BulletCtrl>().damage;
			//Debug.Log(hp);
			monsterState=MonsterState.gothit;
			_animator.SetTrigger("IsHit");
			if(hp<=0){
					monsterState = MonsterState.die;
				_animator.SetTrigger("IsDie");
				Destroy(this.gameObject,5.0f);
				isDie=true;
			}
			Destroy(coll.gameObject);
		}
	}
}

