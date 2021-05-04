using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour{
    //te life of the ship
    public int life;
    //point awarded to player
    public int points;
    //damage done to player
    public int damage;
    //
    public float velocity;
    //
    public float getVelocity(){
        return this.velocity;
    }
    //
    public void setVelocity(float velocity){
        this.velocity = velocity;
    }

    //
    public int getLife(){
        return this.life;
    }
    //
    public void setLife(int life){
        this.life = life;
    }
    //
    public int getPoints(){
        return this.points;
    }
    //
    public void setPoints(int points){
        this.points = points;
    }
    //
    public int getDamage(){
        return this.damage;
    }
    //
    public void setDamage(int damage){
        this.damage = damage;
    }
    //
    public EnemyModel(){

    }
    //
    public EnemyModel(int life, int points, int damage,int velocity){
        this.life = life;
        this.points = points;
        this.damage = damage;
        this.velocity = velocity;
    }

}
