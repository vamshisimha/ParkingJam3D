using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CarMovment : MonoBehaviour
{
   
    public enum DirectionState {e_up,e_down,e_stop}
    public DirectionState myState;

    public float speed;

    public bool IsVertical;
    public bool IsHorizontal;

   public bool n_forward, n_back;
    private void FixedUpdate()
    {
        switch (myState)
        {
            case DirectionState.e_up:
              if (!n_forward )  transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
                break;
            case DirectionState.e_down:
              if(!n_back )  transform.Translate(Vector3.back * Time.fixedDeltaTime * speed);
                break;


            default:
                myState = DirectionState.e_stop;
                break;
        }

    }






































}






