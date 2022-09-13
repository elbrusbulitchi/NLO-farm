using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private FloatingJoystick Joystick;
    [SerializeField] private Animator Anim;
    [SerializeField] private float SpeedPlayer;
    [SerializeField] private float SpeedRotate;
    [SerializeField] private float MaxHeals = 100;
    [SerializeField] private GameObject RotateNloObject;
    [SerializeField] private GameObject NloObject;
    private Rigidbody Rb;
    private float CurrentHeals = 100;
    Vector3 MoveDirection;



    private void Start()
    {
        CurrentHeals = MaxHeals;
        Rb = GetComponent<Rigidbody>();
        //  Anim.SetInteger("Move", 0);
    }

    private void Update()
    {
        RotateNloObject.transform.Rotate(0, 0, 180 * Time.deltaTime);
        if (GameController.Instance.StayGame != GameController.GameStay.Game)
        {
            Rb.velocity = Vector3.zero;
            return;
        }
        if (Input.GetMouseButton(0) && Joystick.transform.GetChild(0).gameObject.activeSelf)
        {

            // Anim.SetInteger("Move", 1);
            float horizontal = Joystick.Direction.x;
            float vertical = Joystick.Direction.y;
           
             MoveDirection = new Vector3(horizontal, 0, vertical);
           // RotatePlayer(MoveDirection);
            NloObject.transform.localEulerAngles = new Vector3(vertical * 10, 0, -horizontal * 10);
            Rb.velocity = MoveDirection * SpeedPlayer;

        }


        if (Input.GetMouseButtonUp(0))
        {
           // Anim.SetInteger("Move", 0);
            Rb.velocity = Vector3.zero;
            Rb.velocity = Vector3.zero;
           NloObject.transform.localEulerAngles = new Vector3(0, 0, 0);

        }
    }
    private void RotatePlayer(Vector3 _Dir)
    {
        Quaternion ToRotate = NloObject.transform.rotation;

            if (_Dir != Vector3.zero)
            {
                ToRotate = Quaternion.LookRotation(_Dir, Vector3.up);
            }
        

        NloObject.transform.rotation = Quaternion.RotateTowards(NloObject.transform.rotation, ToRotate, SpeedRotate * Time.deltaTime);
        NloObject.transform.localEulerAngles = new Vector3(0, NloObject.transform.localEulerAngles.y, 0);



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Animal>())
        {
            other.GetComponent<Animal>().MoveInNLO();
        }
    }
}
   

