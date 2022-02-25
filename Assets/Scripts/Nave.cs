using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    private float speed;

    private Rigidbody2D rb;

    private Collider2D shipCollider;

    private float actualSpeed;

    protected Vector3 limitIzq;

    protected Vector3 limitDer;

    [SerializeField] private GameObject laser;
    // Start is called before the first frame update
    void Start()
    {

        speed = 2.8f;

        rb = GetComponent<Rigidbody2D>();

        shipCollider = GetComponent<Collider2D>();

        limitIzq = new Vector3(-5, -3, 0);

        limitDer = new Vector3(5, -3, 0);

        LaserSpawn(laser, new Vector3(transform.position.x, transform.position.y+0.38f, transform.position.z));
    
    }

    // Update is called once per frame
    void Update()
    {

        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > limitIzq.x){

            actualSpeed = speed;

            transform.Translate(Vector2.left*actualSpeed*Time.deltaTime);

        }else if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < limitDer.x){

            actualSpeed = speed;

            transform.Translate(Vector2.right*actualSpeed*Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space)){

            Debug.Log("Nave: he apretado el gatillo");
            //laser.GetComponent<LaserNave>().IsShot();
            StartCoroutine("CorutSpawn");
        }
    }

    private void LaserSpawn(GameObject laser, Vector3 position){

        Instantiate(laser, position, Quaternion.identity);

    }

    private IEnumerator CorutSpawn(){

        Debug.Log("Se ha iniciado la corrutina");

        yield return new WaitForSeconds(0.4f);

        LaserSpawn(laser, transform.position);
        
    }
}
