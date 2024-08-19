using System;
using UnityEngine;
using UnityEngine.Events;

public class HandRayInteractable:MonoBehaviour{
    [SerializeField]
    private Material OnIdleMaterial;

    [SerializeField]
    private Material OnHoverMaterial;

    [SerializeField]
    private Material TargetMaterial;
    [SerializeField]
    private RoundController roundController;
    public MeshRenderer meshRenderer;
    public UnityEvent OnTargetSelect = new UnityEvent();
    void Start(){
        if(meshRenderer == null){
            meshRenderer = GetComponent<MeshRenderer>();
        }
        SetObjectIdleMaterial();
    }
    public void SetObjectIdleMaterial(){
        if(gameObject == roundController.targetCube){
            meshRenderer.material = TargetMaterial;
        }else{
            meshRenderer.material = OnIdleMaterial;
        }
    }
    public void OnObjectSelect(){
        if(gameObject == roundController.targetCube){
            roundController.endTime = DateTime.Now;
            OnTargetSelect.Invoke();
        }
    }
    public void OnObjectHover(){
        meshRenderer.material = OnHoverMaterial;
        roundController.lastHoverTime = DateTime.Now;
    }
}