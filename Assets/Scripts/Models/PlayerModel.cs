using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour{
    // Start is called before the first frame update
    public int points;
    //damage done to player
    public int actualLevel;


    public int getPoints(){
        return this.points;
    }

    public void setPoints(int points){
        this.points = points;
    }
    //
    public int getActualLevel(){
        return this.actualLevel;
    }

    public void setActualLevel(int actualLevel){
        this.actualLevel = actualLevel;
    }
    //
    public PlayerModel(){

    }
    public PlayerModel(int actualLevel, int points){
        this.points = points;
        this.actualLevel = actualLevel;
    }

}
