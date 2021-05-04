using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum typeEnemy{
    type1,type2,type3
}
public class BehaviourEnemy : EnemyModel{
    //the type of enemy
    public typeEnemy currenTypeEnemy;
    //model of enemy
    public EnemyModel enemy;
    //
    private Image image;
    //
    private Rigidbody2D rigidbody2;
    //
    private Animator animator;
    //
    public GameObject drop1,drop2,drop3;
    //
    private BehaviourPlayer player;
    //
    private GameObject OverZone;
    //
    public AudioClip explotionEffect;
    //method init enemy
    public void initEnemy(){
        if(currenTypeEnemy == typeEnemy.type1){
            //life, points, damage
            enemy = new EnemyModel(1,1,1,0);
        }else if(currenTypeEnemy == typeEnemy.type2){
            //life, points, damage
            enemy = new EnemyModel(2,2,1,0);
        }else if(currenTypeEnemy == typeEnemy.type3){
            //life, points, damage
            enemy = new EnemyModel(4,3,1,0);
        }
    }
    //
    public void movement(){
        //
        if(GameManager.instanciaCompartidaGameManager.currentGameState == GameState.inGame){
            rigidbody2.velocity = Vector2.down * enemy.getVelocity();
        }
    }
    //
    public EnemyModel getEnemyModel(){
        return this.enemy;
    }
    //
    void Update(){
        movement();
    }
    //
    public void initComponents(){
        image = this.GetComponent<Image>();
        rigidbody2 = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        OverZone = GameObject.FindGameObjectWithTag("OverZone");
    }
    //
    void Start(){
        initComponents();
    }
    //
    void Awake(){
        initEnemy();
    }
    //
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bullet")){
            restLife();
            comprobateLife();
        }
        if(other.gameObject.CompareTag("OverZone")){
            GameManager.instanciaCompartidaGameManager.finalGame();
        }
    }
    //
    public float getDistance(){
        float distancia = (OverZone.transform.position.y - this.transform.position.y) * -1;
        print("distancia: "+distancia);
        return distancia;
    }
    public void getPointsPlayer(int points){
        if(getDistance() > 5f){
            GameManager.instanciaCompartidaGameManager.GetPlayer().setPoints(points + enemy.getPoints() + 1);
        }else{
            GameManager.instanciaCompartidaGameManager.GetPlayer().setPoints(points + enemy.getPoints()- 1);
        }
    }
    public void comprobateLife(){
        if(enemy.getLife() >= 1){
            StartCoroutine(onBeat());
        }else if(enemy.getLife() <= 0){
            StartCoroutine(dead());
        }
    }
    public void restLife(){
        enemy.setLife(enemy.getLife() - 1);
    }
    IEnumerator onBeat(){
        restLife();
        animator.SetBool("onBeat",true);
        yield return new WaitForSeconds(.8f);  
        animator.SetBool("onBeat",false);
    }
    IEnumerator dead(){
        AudioSource.PlayClipAtPoint(explotionEffect, new Vector3(5, 1, 2));
        int points = GameManager.instanciaCompartidaGameManager.GetPlayer().getPoints();
        getPointsPlayer(points);
        int pointsUp = GameManager.instanciaCompartidaGameManager.GetPlayer().getPoints();
        GameManager.instanciaCompartidaGameManager.updatePoints(pointsUp);
        animator.SetBool("isLive",false);
        //resatr
        yield return new WaitForSeconds(.8f);
        Destroy(this.gameObject);
    }
}
