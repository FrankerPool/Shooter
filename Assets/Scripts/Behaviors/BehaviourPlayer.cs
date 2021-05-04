using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourPlayer : MonoBehaviour{
    // Start is called before the first frame update
    public Transform gunPosition;
    public GameObject fireTurbine,gunPref;
    public float moveSpeed = 3;
	private Rigidbody2D rigidbody2;
	private float ScreenWidth;
    public GameObject bullet;
    public Transform firePoint;
    private bool rateShoot = true;
    public float timeRate;
    public AudioClip shootEffect;
    void Start(){
        ScreenWidth = Screen.width;
		rigidbody2 = this.GetComponent<Rigidbody2D>();
    }

    public void movementTouch(){
        int i = 0;
		//loop over every touch found
		while (i < Input.touchCount) {
			if (Input.GetTouch (i).position.x > ScreenWidth / 2) {
				//move right
				RunCharacter (1.0f);
			}
			if (Input.GetTouch (i).position.x < ScreenWidth / 2 || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
				//move left
				RunCharacter (-1.0f);
			}
			++i;
		}
    }
    public void movementKeys(){
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            rigidbody2.AddForce(Vector2.left * moveSpeed);
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            rigidbody2.AddForce(Vector2.right * moveSpeed);
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            //shoot
            shoot();
        }
    }
    private void RunCharacter(float value){
		//move player
		rigidbody2.AddForce(new Vector2(value * moveSpeed * Time.deltaTime, 0));

	}
    // Update is called once per frame
    void FixedUpdate(){
        if(GameManager.instanciaCompartidaGameManager.currentGameState == GameState.inGame){
            movementKeys();
            movementTouch();
        }else if(GameManager.instanciaCompartidaGameManager.currentGameState == GameState.gameOver){
            Destroy(this.gameObject);
        }
    }
    //
    IEnumerator shootBullet(){
        rateShoot = false;
        AudioSource.PlayClipAtPoint(shootEffect, new Vector3(5, 1, 2));
        Instantiate(bullet,firePoint.position,firePoint.rotation);
        yield return new WaitForSeconds(timeRate);
        rateShoot = true;
    }
    //
    public void shoot(){
        if(rateShoot == true){
            StartCoroutine(shootBullet());
        }
    }
    //
}
