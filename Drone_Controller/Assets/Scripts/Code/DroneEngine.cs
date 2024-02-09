using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ConaLuk
{

    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, Engine
    {
        #region Variables
        [Header("Engine Properties")]

        [SerializeField] private float maxPower = 10f;


        #endregion

        #region Interface Methods


        public void InitialseEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, DroneInputs inputs)
        {
            // Debug.Log("Running Engine " + gameObject.name);

            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float difference = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * difference; 

            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (inputs.Throtle * maxPower)) / 4f;

            rb.AddForce(engineForce, ForceMode.Force);
        }


        #endregion

    }
}