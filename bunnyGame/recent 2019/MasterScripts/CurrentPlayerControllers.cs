using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CONTROLLS
{
    [System.Serializable]
    public class CurrentPlayerControllers : MonoBehaviour
    {







        static public CurrentPlayerControllers Instance { get { return _instance; } }
        static protected CurrentPlayerControllers _instance;
        //Handeling exeptions do not edit this.
        public void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("CurrentPlayerControllers is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Instantiating new", gameObject);
                _instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
