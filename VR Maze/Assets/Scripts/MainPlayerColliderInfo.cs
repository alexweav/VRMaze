using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class MainPlayerColliderInfo : MonoBehaviour
    {
        GameObject currentCollidingGO;

        // Use this for initialization
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision other)
        {
        if (other.gameObject.name == "Cell Floor")
            currentCollidingGO = other.gameObject.transform.parent.gameObject;
        //Debug.Log(currentCollidingGO.name);    
        }


        public GameObject GetCollidingObject()
        {
            return currentCollidingGO;
        }

       
        
        



    }

