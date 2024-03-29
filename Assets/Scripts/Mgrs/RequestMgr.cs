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
            GameLoop.Instance.gameObject.AddComponent<InviteTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<InvitedTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<JoinTeamRequestRequest>();
            GameLoop.Instance.gameObject.AddComponent<RefusedInviteTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<AcceptInviteTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<AcceptedInviteTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<RefuseInviteTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<GetTeammatesRequest>();
            GameLoop.Instance.gameObject.AddComponent<LeaveTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<TeammateLeaveTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<BreakTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<UpdatePlayerInfoRequest>();
            GameLoop.Instance.gameObject.AddComponent<RefuseJoinTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<RefusedJoinTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<AcceptedJoinTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<AcceptJoinTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<PlayerJoinTeamRequest>();
            GameLoop.Instance.gameObject.AddComponent<KickPlayerRequest>();
            GameLoop.Instance.gameObject.AddComponent<RegenerationRequest>();
            GameLoop.Instance.gameObject.AddComponent<ShoppingRequest>();
            GameLoop.Instance.gameObject.AddComponent<GetItemInfoRequest>();
            GameLoop.Instance.gameObject.AddComponent<EquipItemRequest>();
            GameLoop.Instance.gameObject.AddComponent<UnlockItemSubPropRequest>();
            GameLoop.Instance.gameObject.AddComponent<RefreshItemSubPropRequest>();
            GameLoop.Instance.gameObject.AddComponent<RefreshGunCorePropRequest>();
            GameLoop.Instance.gameObject.AddComponent<AttackInviteRequest>();
            GameLoop.Instance.gameObject.AddComponent<StartAttackRequest>();
            GameLoop.Instance.gameObject.AddComponent<AttackLeaveRequest>();
            GameLoop.Instance.gameObject.AddComponent<UpdateAttackingInfoRequest>();
            GameLoop.Instance.gameObject.AddComponent<HitRegRequest>();
            GameLoop.Instance.gameObject.AddComponent<BeatEnemyRequest>();
            GameLoop.Instance.gameObject.AddComponent<AttackEndRequest>();
            GameLoop.Instance.gameObject.AddComponent<TeamMasterAttackNotifyRequest>();
            GameLoop.Instance.gameObject.AddComponent<ReadyAttackRequest>();
            GameLoop.Instance.gameObject.AddComponent<CancelReadyAttackRequest>();
            GameLoop.Instance.gameObject.AddComponent<AttackInvitedRequest>();
            
        }

        private Dictionary<ActionCode, IRequest> requestDict = new Dictionary<ActionCode, IRequest>();

        public void AddRequest(IRequest request){
            requestDict.Add(request.ActionCode, request);
        }

        public void RemoveRequest(IRequest request){
            requestDict.Remove(request.ActionCode);
        }

        public void HandleResponse(MainPack mainPack){
            // Debug.Log("处理响应："+mainPack.ActionCode);
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

