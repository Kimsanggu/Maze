using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Name_Maze;
public class UserAccount : MonoBehaviour {
	private List<Character> CharacterList;
	private string GuildName;
	private int Gold;
	private int Jewel;
	private	 string PlayerID = "";
	private List<Maze> MazeList;
	private Friend FriendList;
	// Use this for initialization
	void Awake(){
		CharacterList = new List<Character> ();
		AddCharacterList (new Character1 ());
		
		SetPlayerID ("sanggu");
		SetGold (1000);
		SetJewel (500);
		SetGuildName ("Guild");
		DontDestroyOnLoad (transform.gameObject);	
	}
	void Start () {



	}
	public UserAccount(){

	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (GetPlayerID());
		SetPlayerID ("sanggu");
		Debug.Log ("useraccount");
	}
	public void AddCharacterList(Character character){
		this.CharacterList.Add(character);
	}
	public void SetCharacterList(List<Character> CharacterList){
		this.CharacterList = CharacterList;
	}
	public List<Character> GetCharacterList(){
		return this.CharacterList;

	}
	public void SetGuildName(string GuildName){
		this.GuildName = GuildName;
	}
	public string GetGuildName(){
		return this.GuildName;
	}
	public void SetGold(int Gold){
		this.Gold = Gold;
	}
	public int GetGold(){
		return this.Gold;
	}
	public void SetJewel(int Jewel){
		this.Jewel = Jewel;
	}
	public int GetJewel(){
		return this.Jewel;
	}
	public void SetPlayerID(string ID){
		this.PlayerID = PlayerID;
	}
	public string GetPlayerID(){
		return this.PlayerID;
	}
	public void SetMazeList(List<Maze> MazeList){
		this.MazeList = MazeList;
	}
	public List<Maze> GetMazeList(){
		return this.MazeList;
	}
	void SetFriendList(Friend FriendList){
		this.FriendList = FriendList;
	}
	public Friend GetFriendList(){
		return this.FriendList;
	}
}
