using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

namespace ReTouchGunFire.Mgrs{
    public sealed class RequestMgr : IManager
    {
        public RequestMgr(){
            Name = "RequestMgr";
        }

        public override void Init(){
            GameLoop.Instance.gameObject.AddComponent<AcceptFriendRequestRequest>();
            GameLoop.Instance.gameObject.AddComponent<GetFriendRequestRequest>();
            GameLoop.Instance.gameObject.AddComponent<GetFriendsRequest>();
            GameLoop.Instance.gameObject.AddComponent<GetPlayerBaseInfoRequest>();
            GameLoop.Instance.gameObject.AddComponent<InitPlayerInfoRequest>();
            GameLoop.Instance.gameObject.AddComponent<LoginRequest>();
            GameLoop.Instance.gameObject.AddComponent<RegisterRequest>();
            GameLoop.Instance.gameObject.AddComponent<SearchFriendRequest>();
            GameLoop.Instance.gameObject.AddComponent<SendRequestFriendRequest>();
            GameLoop.Instance.gameObject.AddComponent<DeleteFriendRequest>();
            GameLoop.Instance.gameObject.AddComponent<RefuseFriendRequestRequest>();
        }

        private Dictionary<ActionCode, IRequest> requestDict = new Dictionary<ActionCode, IRequest>();

        public void AddRequest(IRequest request){
            requestDict.Add(request.ActionCode, request);
        }

        public void RemoveRequest(IRequest request){
            requestDict.Remove(request.ActionCode);
        }

        public void HandleResponse(MainPack mainPack){
            Debug.Log("处理响应");
            if(requestDict.TryGetValue(mainPack.ActionCode, out IRequest request)){
                request.OnResponse(mainPack);
            }else{
                Debug.LogWarning(mainPack.ActionCode+" 找不到对应的处理.");
            }
        }

        public IRequest GetRequest(ActionCode actionCode){
            if(requestDict.TryGetValue(actionCode, out IRequest request)){
                return request; 
            }else{
                Debug.LogWarning(actionCode +" 找不到对应的Request.");
                return null;
            }
        }
    }

}

