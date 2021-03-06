﻿using Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BeeFly;

[CreateAssetMenu(fileName = "SignManager", menuName = "Managers/SignManager")]
class SignManager : ManagerBase
{
    [SerializeField]
    GameObject prefabOfMain;
    [SerializeField]
    GameObject prefabOfSecondary;
    [SerializeField]
    GameObject prefabOfStop;

    public GameObject[] signArray;
    public Dictionary<int, int> TS;

    void InstantiateTrafficSign(PositionRotation[] PRTL, int Count, Transform parent)
    {
        signArray = new GameObject[Count];
        for (int i = 0; i < Count; i++)
        {
            if (i % 2 == 0)
            {
                signArray[i] = Instantiate(prefabOfMain, parent.transform, false);
                TS.Add(PRTL[i].NumberOfPosition, TrafficSign.Main);
            }
            else
            {
                signArray[i] = Instantiate(prefabOfSecondary, parent.transform, false);
                TS.Add(PRTL[i].NumberOfPosition, TrafficSign.Secondary);
            }
            PRTL[i].SetPR(signArray[i]);
        }
    }

    public void GenerationTrafficSigns(RoadSituation road, Transform parent)
    {
        if (road.trafficSign != TrafficSign.Empty)
        {
            TS = new Dictionary<int, int>(3);

            InstantiateTrafficSign(road.posRotSign, road.CountOfSigns, parent);
        }
    }
    public void ClearSigns()
    {
        if (TS!=null)
        {
            TS = null;
        }
        if (signArray!=null)
        {
            foreach (GameObject sign in signArray)
            {
                if (sign!=null)
                {
                    Destroy(sign);
                }
            }
        }   
    }
    public void GenerationTrafficSigns()
    {
    }
}
