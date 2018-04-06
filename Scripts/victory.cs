using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;



public class victory : MonoBehaviour {

	

public Sprite boti;
public Sprite hami;
public Sprite veti;
public Sprite raii;

public Text result;
public Image pic;

public AudioSource ger;
public AudioSource uk;
public AudioSource fin;

private int bot = 0;
private int ham = 0;
private int vet = 0;
private int rai = 0;


void Start () {
	
	bot = manager.bottas;
	ham = manager.hamilton;
	vet = manager.vettel;
	rai = manager.raikkonen;

	if(bot > ham && bot > vet && bot > rai) {
		result.text = "Bottas is the world champion !";
		fin.Play();
		pic.sprite = boti;
	}
	else if(ham > bot && ham > vet && ham > rai) {
		result.text = "Hamilton is the world champion !";
		uk.Play();
		pic.sprite = hami;
	}
	else if(vet > ham && vet > bot && vet > rai) {
		result.text = "Vettel is the world champion !";
		ger.Play();
		pic.sprite = veti;
	}
	else if(rai > ham && rai > vet && rai > bot) {
		result.text = "Raikkonen is the world champion !";
		fin.Play();
		pic.sprite = raii;
	}
	else { result.text = "Tie"; }
	
	
}
	
	



}
