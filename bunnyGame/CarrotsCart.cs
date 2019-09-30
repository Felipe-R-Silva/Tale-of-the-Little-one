using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotsCart : MonoBehaviour
{
    [SerializeField]
    GameObject carrotquest;
    [SerializeField]
    public List<GameObject> allChildren = new List<GameObject>();
    [SerializeField]
    GameObject parentOfAllCarrots;
    public int ActivationCount = 0;
    // Use this for initialization
    void Start()
    {
        AddChilfrenTolist(allChildren, parentOfAllCarrots);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Carrot_Planted" && ActivationCount< allChildren.Count)
        {
            if(carrotquest.GetComponent<QuestMaster>().CarrotQuest.questState[3].CompleatedRequirements == false)
            {
                carrotquest.GetComponent<QuestMaster>().CarrotQuest.questState[3].CompleatedRequirements = true;
            }
            else if(ActivationCount>=23 && carrotquest.GetComponent<QuestMaster>().CarrotQuest.questState[4].CompleatedRequirements == false)
            {
                carrotquest.GetComponent<QuestMaster>().CarrotQuest.questState[4].CompleatedRequirements = true;
            }
            TurnOnCarrot(ref ActivationCount, allChildren);
            Destroy(other.gameObject);
        }

    }
    void AddChilfrenTolist(List<GameObject> allChildren, GameObject parent)
    {
        int children = parent.transform.childCount;
        for (int i = 0; i < children; ++i)
            allChildren.Add(parent.transform.GetChild(i).gameObject);
    }
    void TurnOnCarrot(ref int count, List<GameObject> allChildren)
    {
        allChildren[count].SetActive(true);
        count++;
    }
    public void EmptyCart(ref int count, List<GameObject> allChildren)
    {
        for (int k = 0; k < allChildren.Count; k++)
        {
            allChildren[k].SetActive(false);
        }
        count=0;
    }

}
