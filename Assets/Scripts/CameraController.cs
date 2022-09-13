using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float Speed;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
        transform.position = transform.position - transform.forward*8;
    }

    void LateUpdate()
    {
       
    }
    private void Update()
    {
        if(GameController.Instance.StayGame == GameController.GameStay.Game)
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Speed * Time.deltaTime);
    }
}
