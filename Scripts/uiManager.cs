using UnityEngine;

using UnityEngine.UI;

using System.Collections;

using UnityEngine.SceneManagement;


public class uiManager : MonoBehaviour 
{


public Button[] buttons;

public Text scoreText;
public Text ending;

public AudioSource exp;
public AudioSource jee;
int score;	
bool winner;
bool won = false;
bool gameOver;
		
public int manag = 0;
int ham = 0;
int vet = 0;
int rai = 0;
int bot = 0;

void Start () {
	
	winner = false;
	gameOver = false;
	
	score = 20;
	   
	if(manag == 2) { ending.enabled = false; }	
	InvokeRepeating("scoreUpdate", 3f, 3f);
	
}
	
	

void Update () {
	
	if(manag == 2) { scoreText.text = "Position : " + score;
 }
}

	

void scoreUpdate(){
		
	if(gameOver == false){
			
		score -= 1;

		if(score == 1) 
		{	
			winner = true;
			gameOverActivatated();
		}		
	}
		
}

	

public void gameOverActivatated(){


	if(winner == true && won == false && manag == 2) {
		jee.Play();
		won = true;
		manager.bot = 1;
		bot = 1;
		manager.bottas += 25;	
		pointsGiven();
		gameOver = true;

		ending.text = "1st";
		ending.enabled = true;

		StartCoroutine(Next());	
		return;	
	}
	if(won == true) { return; }
	
	exp.Play();

	if(manag != 2) { return; }
	
	gameOver = true;


	if(score == 1) { 
		ending.text = score.ToString() + "st"; }
	else if(score == 2) { 
		ending.text = score.ToString() + "nd"; }
	else if(score == 3) { 
		ending.text = score.ToString() + "rd"; }
	else if(score > 3) { 
		ending.text = score.ToString() + "th"; }

	if(manag == 2) { ending.enabled = true; }	

	player();
	pointsGiven();

        StartCoroutine(Next());
}

	

IEnumerator Next(){
	yield return new WaitForSeconds(3);
	SceneManager.LoadScene("standing", LoadSceneMode.Single);
}
IEnumerator Ends(){
	yield return new WaitForSeconds(3);
	SceneManager.LoadScene("victory", LoadSceneMode.Single);
}

void pointsGiven(){
	others();	
	manager.race += 1;
}

void player(){
	if(score == 1) { manager.bottas += 25; }
	else if(score == 2) { manager.bottas += 18; }
	else if(score == 3) { manager.bottas += 15; }
	else if(score == 4) { manager.bottas += 12; }
	else if(score == 5) { manager.bottas += 10; }
	else if(score == 6) { manager.bottas += 8; }
	else if(score == 7) { manager.bottas += 6; }
	else if(score == 8) { manager.bottas += 4; }
	else if(score == 9) { manager.bottas += 2; }
	else if(score == 10) { manager.bottas += 1; }

	manager.bot = score;
	bot = score;
}

void others(){
	ham = Random.Range(1,12);
	while(bot == ham) { ham = Random.Range(1,12) ; }
	vet = Random.Range(1,12);
	while(vet == ham || bot == vet) { vet = Random.Range(1,12) ; }
	rai = Random.Range(1,15);
	while(rai == ham || rai == vet || bot == rai) { rai = Random.Range(1,15); }

	manager.ham = ham;
	manager.vet = vet; 
	manager.rai = rai;

	if(ham == 1) { manager.hamilton += 25; }
	else if(ham == 2) { manager.hamilton += 18; }
	else if(ham == 3) { manager.hamilton += 15; }
	else if(ham == 4) { manager.hamilton += 12; }
	else if(ham == 5) { manager.hamilton += 10; }
	else if(ham == 6) { manager.hamilton += 8; }
	else if(ham == 7) { manager.hamilton += 6; }
	else if(ham == 8) { manager.hamilton += 4; }
	else if(ham == 9) { manager.hamilton += 2; }
	else if(ham == 10) { manager.hamilton += 1; }

	if(vet == 1) { manager.vettel += 25; }
	else if(vet == 2) { manager.vettel += 18; }
	else if(vet == 3) { manager.vettel += 15; }
	else if(vet == 4) { manager.vettel += 12; }
	else if(vet == 5) { manager.vettel += 10; }
	else if(vet == 6) { manager.vettel += 8; }
	else if(vet == 7) { manager.vettel += 6; }
	else if(vet == 8) { manager.vettel += 4; }
	else if(vet == 9) { manager.vettel += 2; }
	else if(vet == 10) { manager.vettel += 1; }

	if(rai == 1) { manager.raikkonen += 25; }
	else if(rai == 2) { manager.raikkonen += 18; }
	else if(rai == 3) { manager.raikkonen += 15; }
	else if(rai == 4) { manager.raikkonen += 12; }
	else if(rai == 5) { manager.raikkonen += 10; }
	else if(rai == 6) { manager.raikkonen += 8; }
	else if(rai == 7) { manager.raikkonen += 6; }
	else if(rai == 8) { manager.raikkonen += 4; }
	else if(rai == 9) { manager.raikkonen += 2; }
	else if(rai == 10) { manager.raikkonen += 1; }
}

// AUS, CHI, BAH, RUS, SPA, MON, CAN, EU, AUT, UK
// HUN, BEL, ITA, SIN, MAL, JAP, USA, MEX, BRA, AD
// -1

public void Play(){
			
	if(manag == 1) { 
		if(manager.race == 20) { SceneManager.LoadScene("victory", LoadSceneMode.Single); }

		if( manager.race == 3 || manager.race == 5 || manager.race == 7 || manager.race == 16) {
			SceneManager.LoadScene("level1", LoadSceneMode.Single);
		}
		else if(manager.race < 2 || manager.race == 4 || manager.race == 6 || manager.race == 8
			|| manager.race == 9 
			|| manager.race == 12 || manager.race == 14
			|| manager.race == 15 
			|| manager.race == 18) {
			SceneManager.LoadScene("level2", LoadSceneMode.Single);
		}
		else if(manager.race == 2 || manager.race == 10 || manager.race == 11
			|| manager.race == 13 || manager.race == 17
			|| manager.race == 19) {
			SceneManager.LoadScene("level3", LoadSceneMode.Single);
		}

	}
	else if(manag == 3) { reset(); SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);; }
	else  {  SceneManager.LoadScene("standing", LoadSceneMode.Single);}	

	
}

	

void reset(){
	manager.bottas = 0;
	manager.hamilton = 0;
	manager.vettel = 0;
	manager.raikkonen = 0;
	manager.bot = 0;
	manager.ham = 0;
	manager.vet = 0;
	manager.rai = 0;
	manager.race = 0;
}

public void Pause(){
		
	if (Time.timeScale == 1){
			
		Time.timeScale = 0;

		foreach(Button button in buttons){
			
			button.gameObject.SetActive(true); 		
	}
			
		
	}
		
	else if (Time.timeScale == 0){
			
		Time.timeScale = 1;
			
		
	}
	
}


  

public void Replay(){
 
	SceneManager.LoadScene("level1", LoadSceneMode.Single);  
}

  

public void Menu(){
 	
	SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
}

  

public void Exit(){
  	
	Application.Quit();
  
}

}
