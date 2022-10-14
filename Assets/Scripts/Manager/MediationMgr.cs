using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediationMgr : IManager
{
    public MediationMgr(){
        Name = "MediationMgr";
    }

    private Dictionary<string,IMediation> mediationList = new Dictionary<string,IMediation>();

    public void AddMediation(IMediation mediation){
        mediationList.Add(mediation.Name,mediation);
    }

    public void RemoveMediation(IMediation mediation){
        mediationList.Remove(mediation.Name);
    }

    public IMediation GetMediation(IMediation mediation){
        if(mediationList.TryGetValue(mediation.Name,out IMediation mediationValue)){
            return mediationValue;
        }
        return null;
    }
}
