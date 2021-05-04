using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourLevelSettings : MonoBehaviour{
    // public AudioClip levelMusic;
    void Start(){
        // AudioSource.PlayClipAtPoint(levelMusic, new Vector3(5, 1, 2));
    }
    
    void Update(){
        if(GameManager.instanciaCompartidaGameManager.currentGameState == GameState.gameOver){
            Destroy(this.gameObject);
        }
    }
}
