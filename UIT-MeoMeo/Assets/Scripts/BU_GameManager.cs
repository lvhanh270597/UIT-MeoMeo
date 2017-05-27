/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] gameOjects;
	public static GameManager instance = null;
	public int rows;
	public int Max_nums;
	public float bottom; 
	public float velOnEachFrame;
	private List <List <GameObject> > Objects; 

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this){
			Destroy (gameObject);
		}
	}
	void Start(){
		initGame ();
	}
	private GameObject createNewObject(float x, int y){
		int type = Random.Range (0, gameOjects.Length);
		GameObject g = GameObject.Instantiate(gameOjects[type]);
		g.transform.position = new Vector2 (x, y);
		return g;
	}
	private float randomX(){
		return Random.Range (0f, 0f);
	}
	private List<GameObject> createNewRow(int x = 0){
		List <GameObject> temp = new List<GameObject>();
		int cols = Random.Range (0, Max_nums);
		float before = -3.6f;
		for (int j = 0; j < cols; j++) {			
			float random = randomX ();
			temp.Add (createNewObject(before + random, x));
			before += random;
		}
		return temp;
	}
	private void initGame(){					
		Objects = new List<List<GameObject>> ();
		for (int i = 0; i < rows; i++) { Objects.Add (createNewRow(i)); }
	}

	// Use this for initialization
	void InstanceNewRow(int x){		
		int nums = Random.Range (1, Max_nums);
		int count = Objects [x].Count;

		for (int i = 0; i < count; i++) {
			Destroy (Objects[x][i].gameObject);
		}
		Objects [x].Clear ();

		float before = -3.6f;
		for (int i = 0; i < nums; i++) {	
			int type = Random.Range (0, gameOjects.Length);
			Objects [x].Add(GameObject.Instantiate (gameOjects[type]));
			float random = randomX ();
			Objects [x] [i].transform.Translate (new Vector2(before + random, 3f));
			before += random;
		}
	}
	// Update is called once per frame
	void Update () {		
		for (int i = 0; i < rows; i++) {			
			bool updated = false;
			for (int j = 0; j < Objects [i].Count; j++) {
				Vector2 pos = new Vector2(Objects [i] [j].transform.position.x, Objects[i][j].transform.position.y - velOnEachFrame);										
				if (pos.y <= bottom) {
					updated = true;
					break;
				}
				Objects [i] [j].transform.position = pos;
			}	
			if (updated) {
				InstanceNewRow (i);
			}
		}
	}
}
*/