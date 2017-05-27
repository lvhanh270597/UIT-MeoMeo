using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] gameOjects;
	public static GameManager instance = null;
	public int rows;
	public float bottom; 
	public float top;
	public float velOnEachFrame;
	public GameObject bg;
	private float width;
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
		g.transform.position = new Vector3 (x, y, -2f);
		return g;
	}
	private float randomX(){
		return Random.Range (2f, 3f);
	}
	private List<GameObject> createNewRow(int x = 0){
		List <GameObject> temp = new List<GameObject>();
		float random = randomX ();
		float before = -width + Random.Range(0.5f, 1.5f);
		while (before <= width - 0.5f) {			
			temp.Add (createNewObject(before, 2 * x));
			random = randomX ();
			before += random;

			int tmp = Random.Range (1, 5);
			if (tmp == 1)
				break;
		}
		return temp;
	}
	private void initGame(){	
		width = bg.GetComponent<SpriteRenderer> ().bounds.extents.x;
		Objects = new List<List<GameObject>> ();
		for (int i = 0; i < rows; i++) { Objects.Add (createNewRow(i)); }
	}

	// Use this for initialization
	void InstanceNewRow(int x){				
		int count = Objects [x].Count;

		for (int i = 0; i < count; i++) {
			Destroy (Objects[x][i].gameObject);
		}
		Objects [x].Clear ();
			
		int ii = 0;
		float random = randomX ();
		float before = -width + Random.Range(0.5f, 1.5f);
		while (before <= width - 0.5f){
			int type = Random.Range (0, gameOjects.Length);
			Objects [x].Add(GameObject.Instantiate (gameOjects[type]));
			Objects [x] [ii].transform.Translate (new Vector3(before, top, -2f));
			random = randomX ();
			before += random;
			ii++;

			int tmp = Random.Range (1, 5);
			if (tmp == 1)
				break;
		}

	}
	// Update is called once per frame
	void Update () {		
		for (int i = 0; i < rows; i++) {			
			bool updated = false;
			for (int j = 0; j < Objects [i].Count; j++) {
				Vector3 pos = new Vector3(Objects [i] [j].transform.position.x, Objects[i][j].transform.position.y - velOnEachFrame, -2f);										
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
