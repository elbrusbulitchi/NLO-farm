using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float SpeedMoveInNLO;
    private bool MoveActive = false;
    private GameObject NLO;

    private void Update()
    {
        if (MoveActive)
        {
            transform.position = Vector3.Lerp(transform.position, NLO.transform.position, SpeedMoveInNLO*Time.deltaTime);
            
        }
    }

    public void MoveInNLO()
    {
        if (MoveActive)
            return;
        MoveActive = true;
        NLO = PlayerController.Instance.gameObject;
        transform.parent = NLO.transform;
        transform.DORotate(new Vector3(0, 720, 0), 0.99f, RotateMode.FastBeyond360);
        transform.DOScale(0, 1f).OnComplete(() => {

            Destroy(gameObject);
        });

    }
}
