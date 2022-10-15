using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public sealed class RequestMgr : IManager
{
    public RequestMgr(){
        Name = "RequestMgr";
    }

    public override void Init(){
        
    }

    private Dictionary<ActionCode, IRequest> m_requestDict = new Dictionary<ActionCode, IRequest>();

    public void AddRequest(IRequest request){
        m_requestDict.Add(request.ActionCode, request);
    }

    public void RemoveRequest(IRequest request){
        m_requestDict.Remove(request.ActionCode);
    }

    public void HandleResponse(MainPack mainPack){
        if(m_requestDict.TryGetValue(mainPack.ActionCode, out IRequest request)){
            request.OnResponse(mainPack);
        }else{
            Debug.LogWarning(mainPack.ActionCode+" 找不到对应的处理.");
        }
    }
}
