
using System;
using Game.General.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace Tantawowa.Demo.DemoScripts
{
    
    public enum GameState
    {
        Sleeping,
        GoToWork,
        GoHome,
        fart,
    }

    public class MyTimelineFunctions : MonoBehaviour
    {
        public GameObject crane;
        public GameObject RatCraneTimelineObj;
        public GameObject CameraMain;
        public GameObject MoveRatTothisPoint;
        public GameObject RAT;

        public GameObject DialogCanvas;
        public GameObject PointsCanvas;
        [SerializeField]
        private int points;

        [SerializeField]
        private GameState currentState;

        public int Points
        {
            get { return points; }
            set
            {
                points = value;
                //Message.text = points > 0 ? points.ToString() : "";
            }
        }

        public void moveRat()
        {
            RAT.transform.position = MoveRatTothisPoint.transform.position;
        }
        public void AddScore(int points)
        {
            Points += points;
        }

        public void ResetScore()
        {
            Points = 0;
        }
        public void TurnFlagOn()
        {
            crane.GetComponent<MoveCrane>().TimeToGrabTrack = true;

        }
        public void EndTimeline()
        {
            RatCraneTimelineObj.SetActive(false);
            CameraMain.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
        }
        public void TurnOnDialogCanvasAndPointsCanvasON()
        {
            DialogCanvas.SetActive(true);
            PointsCanvas.SetActive(false);

        }
        public void TurnOnDialogCanvasAndPointsCanvasOff()
        {
            DialogCanvas.SetActive(false);
            PointsCanvas.SetActive(true);

        }

        public void SetState(GameState state)
        {
            currentState = state;
            switch (state)
            {
                case GameState.Sleeping:

                    break;
                case GameState.GoToWork:

                    break;
                case GameState.GoHome:

                    break;
                case GameState.fart:
                    print("If I can run any code here this would be amazing");
                    Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
                    //NavMeshFollower.Target = Home;
                    //Agent.speed = 6f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }
        }

        private void Update()
        {
            //Vector3 v = Camera.main.transform.position - transform.position;
            //v.x = v.z = 0.0f;
            //Message.transform.LookAt(Camera.main.transform.position - v);
            //Message.transform.Rotate(0, 180, 0);
        }
    }
}