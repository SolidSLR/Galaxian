using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserNave : MonoBehaviour
{

    public GameObject ship;

    private float shotSpeed;

    private bool isShot;
    
    void Start(){

        ship = GameObject.Find("NaveJugador");

        shotSpeed = 4f;

        isShot = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){

            isShot = true;
        }

        if(isShot == true){

            transform.Translate(Vector2.up*shotSpeed*Time.deltaTime);

        } else if(isShot == false){

            transform.position = new Vector2(ship.transform.position.x, ship.transform.position.y+0.38f);

        }

        if(transform.position.y>ship.transform.position.y+10.38f){

            Debug.Log("Me destruyo");

            Destroy(gameObject);

        }
    }
}
