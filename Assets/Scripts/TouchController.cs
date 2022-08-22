using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    Vector3 firsttouchpoint;
    Vector3 lasttouchpoint;
    GameObject myCar;
    public LayerMask car;
   
    void Update()
    {
       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           
            Ray myRay = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;


            if (touch.phase == TouchPhase.Began)
            {
              
                if (Physics.Raycast(myRay.origin, myRay.direction, out hit, Mathf.Infinity, car))
                {
                    if (hit.collider.tag == "Car")
                    {
                        myCar = hit.collider.gameObject;
                        firsttouchpoint = hit.point;
                       
                    }
                
                }

            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (Physics.Raycast(myRay.origin, myRay.direction, out hit, Mathf.Infinity))
                {
                    
                    lasttouchpoint = hit.point;
                  
                   
                }

                
                HorizontalTouch();
                VerticalTouch();
            
           
            }
        
        }


    }




    void HorizontalTouch()
    {
       
        // Right
        if (lasttouchpoint.x - firsttouchpoint.x > 5)
        {
            CarMovment carsc = myCar?.GetComponent<CarMovment>();
            if (myCar != null && carsc.IsHorizontal)
            {

              
                carsc.myState = CarMovment.DirectionState.e_up;

                lasttouchpoint = Vector3.zero;
                firsttouchpoint = Vector3.zero;
                myCar = null;
            }
           
        }


        //LEFT
        if (lasttouchpoint.x - firsttouchpoint.x < -5)
        {
            CarMovment carsc = myCar?.GetComponent<CarMovment>();
            if (myCar != null && carsc.IsHorizontal)
            {
               
                carsc.myState = CarMovment.DirectionState.e_down;

                lasttouchpoint = Vector3.zero;
                firsttouchpoint = Vector3.zero;
                myCar = null;
           
            }

        }

    }

    void VerticalTouch()
    {

        //UP
        if (lasttouchpoint.z - firsttouchpoint.z > 5)
        {
            CarMovment carsc = myCar?.GetComponent<CarMovment>();
            if (myCar != null && carsc.IsVertical)
            {
               
                carsc.myState = CarMovment.DirectionState.e_up;

                lasttouchpoint = Vector3.zero;
                firsttouchpoint = Vector3.zero;
                myCar = null;
            }

        }

        //DOWN
        if (lasttouchpoint.z - firsttouchpoint.z < -5)
        {

            CarMovment carsc = myCar?.GetComponent<CarMovment>();

            if (myCar != null && carsc.IsVertical)
            {
               
                carsc.myState = CarMovment.DirectionState.e_down;

                lasttouchpoint = Vector3.zero;
                firsttouchpoint = Vector3.zero;
                myCar = null;
            }


        }

    }




}













