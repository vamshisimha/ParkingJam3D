using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    CarMovment carmov;

    //FRONT
    public Vector3 FrontSize;
    public Transform FrontTransform;
    //BACK
    public Vector3 BackSize;
    public Transform BackTransform;

    public LayerMask ColMask;







    private void Start() => carmov = GetComponentInParent<CarMovment>();
    

    void Update() => FrontBack();




    void FrontBack()
    {
       
        Collider[] FrontCol = Physics.OverlapBox(FrontTransform.position, FrontSize / 2,  transform.parent.rotation, ColMask);
        if (FrontCol.Length == 0)
            carmov.n_forward = false;
        for (int i = 0; i < FrontCol.Length; i++)
        {

           if(FrontCol[i].gameObject.tag=="Car" || FrontCol[i].gameObject.tag == "Barrier")
                carmov.n_forward = true;

            OnOut(FrontCol, i);

        }

      
        Collider[] BackCol = Physics.OverlapBox(BackTransform.position, BackSize / 2, transform.parent.rotation, ColMask);
        if (BackCol.Length == 0)
            carmov.n_back = false;
       
        for (int i = 0; i < BackCol.Length; i++)
        {

            if (BackCol[i].gameObject.tag == "Car" || BackCol[i].gameObject.tag == "Barrier")
                carmov.n_back = true;

            OnOut(BackCol, i);


        }


    }
   
    void OnOut(Collider[] _col,int i)
    {
        if (_col[i].gameObject.tag == "MidUp")
        {
            transform.parent.rotation = Quaternion.Euler(0, 90, 0);
            carmov.myState = CarMovment.DirectionState.e_up;
            carmov.speed = 20;

        }
           
        if (_col[i].gameObject.tag == "MidDown")
        {
            transform.parent.position = new Vector3(transform.parent.position.x, 1.7f, transform.parent.position.z);
            transform.parent.rotation = Quaternion.Euler(0, -90, 0);
            carmov.myState = CarMovment.DirectionState.e_up;
            carmov.speed = 20;
        }
           

        if (_col[i].gameObject.tag == "Right")
        {
            transform.parent.rotation = Quaternion.Euler(0, 180, 0);
            carmov.myState = CarMovment.DirectionState.e_up;
            carmov.speed = 20;
        }
           
       
        if (_col[i].gameObject.tag == "Left")
        {
            transform.parent.rotation = Quaternion.Euler(0, 0, 0);
            carmov.myState = CarMovment.DirectionState.e_up;
            carmov.speed = 20;
        }

    }


   

}
