using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookMovement : MonoBehaviour
{
    //rotation on z axis
    public float minimum_Z = -5f, max_Z = 5f;
    public float rotate_Speed = 6f;
    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;
    public float move_Speed = 3.5f;
    private float initial_Move_Speed;
    public float minimum_Y = -2.5f;
    public float minimum_X = -7.0f;
    public float maximum_X = 7.0f;
    private float initial_Y;
    private float current_X;
    private bool moveDown;
    private RopeRenderer ropeRenderer;
    public AudioSource source;
    public AudioClip clip;


    void Awake() {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    //For line renderer
    //Rope renderrer

    // Start is called before the first frame update
    void Start()
    {
        initial_Y = transform.position.y;
        initial_Move_Speed = move_Speed;

        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        int items = GameObject.Find("Items").transform.childCount;
        current_X = transform.position.x;
        if(items<=0){
            SceneManager.LoadScene("Finish");
        }

        Rotate();
        GetInput();
        MoveRope();
    }

    //rotation of rope
    void Rotate() {
        if (!canRotate)
            return;

        if(rotate_Right) {
            rotate_Angle += rotate_Speed * Time.deltaTime;
        } else {
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        if(rotate_Angle >= max_Z) {
            rotate_Right = false;
        } else if(rotate_Angle <= minimum_Z) {
            rotate_Right = true;
        }
        
    }

    //inout on mouse click
    void GetInput() {
        if(Input.GetMouseButtonDown(0)) {
            if (!source.isPlaying) {
                source.PlayOneShot(clip);
            }
            if(canRotate) {
                canRotate = false;
                moveDown = true;
            }
        }
    }

    //move rope down y axis
    void MoveRope() {
        if(canRotate) //do nothing if can rotate
            return;
        if(!canRotate) { //if cannot rotate
            //sound manager
            Vector3 temp = transform.position;
        
            if(moveDown) {
                temp -= transform.up * Time.deltaTime * move_Speed;
            } else {
                temp += transform.up * Time.deltaTime * move_Speed;
        }

        transform.position = temp;

        if ((temp.y <= minimum_Y)||(current_X >= maximum_X)||(current_X <= minimum_X)) {
            moveDown = false;
        }
        if(temp.y >= initial_Y) {
            source.Stop();
            canRotate = true; 

            ropeRenderer.RenderLine(temp, false);
            move_Speed = initial_Move_Speed;
        }

        ropeRenderer.RenderLine(transform.position, true);
        }
    }

    public void returnHook() {
        moveDown = false;
    }
        
}
