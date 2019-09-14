using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviourPun,IPunObservable
    {
        private CarController m_Car; // the car controller we want to use
        public PhotonView pv;


        //  public GameObject opponentCar;
        public Vector3 opponentCarPosition;
        public Vector3 opponenctCarRotation;
        public Vector3 inputValues;
        public Vector3 inputFromOpponent;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        
        }

        

        public void ProcessInputAndMoveCar()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");

            m_Car.Move(h, v, v, handbrake);

            inputValues = new Vector3(h,v,handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
        
        public void SmoothMovement()
        {
            transform.position = Vector3.Lerp(transform.position,opponentCarPosition,Time.deltaTime * 10);
          
            transform.eulerAngles =eulerValues;
            //transform.Rotate(new Vector3(SendingValues[1].x,SendingValues[1].y,SendingValues[1].z));
            //   m_Car.Move(inputFromOpponent.x,inputFromOpponent.y,inputFromOpponent.y,inputFromOpponent.z);

        }
        private void FixedUpdate()
        {
           
            if (photonView.IsMine)
            {
                ProcessInputAndMoveCar();
            }
            else
            {
                SmoothMovement();
            }
            /*
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");

                m_Car.Move(h, v, v, handbrake);
           
            
#else
            m_Car.Move(h, v, v, 0f);
#endif
*/
        }

        public Vector3 eulerValues;
    //    Quaternion latestRot;
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            
            // throw new NotImplementedException();
            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
                //stream.SendNext(transform.rotation);
                stream.SendNext(inputValues);
                
            }
            else if (stream.IsReading)
            {
                opponentCarPosition = (Vector3)stream.ReceiveNext();
                eulerValues = (Vector3)stream.ReceiveNext();
                //  latestRot = (Quaternion)stream.ReceiveNext();
                //  inputFromOpponent = (Vector3)stream.ReceiveNext();

            }
        }
    }
}
