using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Place_Tower : MonoBehaviour 
{

	public GameObject turretPrefab;
	private GameObject turret;

	//Søger for at man ikke kan placere flere end 1 tower på et spot.
	private bool CanPlaceTower () {
  		int cost = turretPrefab.GetComponent<TowerData>().levels[0].cost;
		return turret == null && gameManager.BITCOIN >= cost;

	 }


//1
void OnMouseUp()
{
  //2
  if (CanPlaceTower())
  {
    //3
    turret = (GameObject) 
      Instantiate(turretPrefab, transform.position, Quaternion.identity);
    //4
    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
    audioSource.PlayOneShot(audioSource.clip);
    gameManager.BITCOIN -= turret.GetComponent<TowerData>().CurrentLevel.cost;


  }

	else if (CanUpgradeTower())
	{
 	 	turret.GetComponent<TowerData>().IncreaseLevel();
 		 AudioSource audioSource = gameObject.GetComponent<AudioSource>();
 	 	audioSource.PlayOneShot(audioSource.clip);
  		gameManager.BITCOIN -= turret.GetComponent<TowerData>().CurrentLevel.cost;

	}

}

private bool CanUpgradeTower()
{
  if (turret != null)
  {
    TowerData TowerData = turret.GetComponent<TowerData>();
    TowerLevel nextLevel = TowerData.GetNextLevel();
    if (nextLevel != null)
    {
      return gameManager.BITCOIN >= nextLevel.cost;
    }
  }
  return false;
}

private GameManagerBehavior gameManager;

void Start(){
	gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();


}

}
