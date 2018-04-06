using UnityEngine;

using System.Collections;


public class carSpawner : MonoBehaviour 
{


public GameObject[] cars; 

public float maxPos = 2.2f;

public float delayTimer = 0.5f;

float timer;
	
int carNo;

void Start () {
	
	timer = delayTimer;
	
	
}
	
	

void Update () {

	
	timer -= Time.deltaTime; 
	
	if (timer <= 0) {
		
		Vector3 carPos = new Vector3(Random.Range(-2.2f,2.2f),transform.position.y,transform.position.z);

	
		carNo = Random.Range (0,6);
	
		Instantiate (cars[carNo], carPos, transform.rotation);
	timer = delayTimer;
	
	}
	
	

}

}
