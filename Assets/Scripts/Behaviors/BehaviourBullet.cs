using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourBullet : MonoBehaviour{
    // Start is called before the first frame update
    public float speed = 20f;
    //
    public float lifetime = 5.0f;
    //
    private Rigidbody2D rigidbody2;
    //public Rigidbody2D rigidbody;
    void Start(){
        rigidbody2 = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void destruir(){
        Destroy(this.gameObject);
    }
    //
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            destruir();
        }
    }

    // Update is called once per frame
    void Update(){
        rigidbody2.velocity = Vector2.up * speed;
    }
}
