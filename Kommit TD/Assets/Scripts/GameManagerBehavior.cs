using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerBehavior : MonoBehaviour {
public Text BitcoinLabel;

private int Bitcoin;
public int BITCOIN {
  get
  { 
    return Bitcoin;
  }
  set
  {
    Bitcoin = value;
    BitcoinLabel.GetComponent<Text>().text = "BITCOINS: " + Bitcoin;
  }
}

void Start(){

	BITCOIN = 1000;

}

}
