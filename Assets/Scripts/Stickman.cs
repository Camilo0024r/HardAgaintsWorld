using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour {

    //Declaración variables camara movimiento
    Transform tr;
    public Transform cameraShoulder; //Eje de la cámara
    public Transform cameraHolder; //posición y rotación de la cámara con respecto al personaje
    private Transform cam;
    private float rotY = 0f;  //rotación
    public float rotationSpeed = 200; //velocidad de rotación cámara
    public float minAngle = -45; //angulo minimo de la cámara
    public float maxAngle = 4; // angulo maximo de la cámara
    public float cameraSpeed = 200; //velocidad de la cámara

    //Animaciones
    Animator anim;
    private Vector2 animSpeed;

   //Declaración variables movimiento stickman
    Rigidbody stickman;
    public float walkSpeed = 9000;

    //Declaración variables efecto sonido
    public AudioClip sonidoCaminando;
    public AudioClip sonidoSalto;
    private AudioSource sonidoStickman;

    //Declaración salto stickman
    public float jumpForce = 85;
    public bool OnGround;
     //variable que indica cuando salte
     public bool Jumping;
     //Activador salto
     public GameObject triggerJump;


    // Start is called before the first frame update
    void Start(){

        //Inicialización variables movimiento cámara
         tr = this.transform;
        cam = Camera.main.transform;

        //Inicialización variable movimiento stickman
        stickman = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //sonidoStickman = GetComponent<AudioSource>();
  
    }

    // Update is called once per frame
    void Update()
    {

        CameraControl();
        MoveControl();
        ActionsControl();
        AnimControl();
    }

    //Función rotación stickman
    public void CameraControl(){

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * rotationSpeed * deltaT;
        float rotX = mouseX * rotationSpeed * deltaT;

        tr.Rotate(0,rotX,0);
        rotY = Mathf.Clamp(rotY, minAngle,maxAngle);
        
        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        cameraShoulder.localRotation = localRotation;
        cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
    }

    //Limite movimiento stickman
    public void limitMovement(){

        //Limite movimiento hacia el eje z
        if(transform.position.z < -30){
            transform.position = new Vector3(-30,transform.position.y, transform.position.x);
        }
        if(transform.position.z> 11){
            transform.position = new Vector3(11,transform.position.y, transform.position.x);
        }

        //Limite movimiento hacia el eje x

        //Limite movimiento haci adelante
        if(transform.position.x< 230){
            transform.position = new Vector3(230,transform.position.y, transform.position.z);
        }

        //Limite movimiento hacia atras
         if(transform.position.x> 250){
            transform.position = new Vector3(250,transform.position.y, transform.position.z);}
    }

    //Función movimiento stickman
    public void MoveControl(){

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float deltaT = Time.deltaTime;

        animSpeed = new Vector2(deltaX,deltaZ);

        Vector3 side = walkSpeed * deltaX * deltaT * tr.right;
        Vector3 forward = walkSpeed * deltaZ* deltaT* tr.forward;

        Vector3 direction =  side + forward;

        direction.y = stickman.velocity.y;

        stickman.velocity = direction;

    }

    //Función Salto
    public void ActionsControl(){

        //Salto
        Jumping = Input.GetKey(KeyCode.Space);

        if(OnGround){
            if(Jumping){
                stickman.AddForce(transform.up * jumpForce);
            }
        }
    }

    //Función Animacion
    public void AnimControl(){

        anim.SetFloat("X",animSpeed.x);
        anim.SetFloat("Y",animSpeed.y);
    }
}
