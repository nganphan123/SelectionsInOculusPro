using UnityEngine;

class HandPinchCounter:MonoBehaviour{
    [SerializeField]
    private OVRHand rightHand;
    private bool wasPinching = false;
    [SerializeField]
    private RoundController roundController;
    void Update(){
        if(roundController == null){
            Debug.LogError("Round controller is not assigned.");
            return;
        }
        if(IsHandFirstPinching()){
            roundController.totalAttemptsMade += 1;
        }
    }   

    private bool IsHandFirstPinching(){
        if(rightHand != null){
            return !wasPinching && rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        }else{
            Debug.LogError("OVR hand is not assigned.");
        }
        wasPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        return false;
    }
}
