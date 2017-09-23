using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKhandling : MonoBehaviour {

    Animator anim;

    public float LeftHandWeight;
    public Transform LeftHandTarget;

    public float RightHandWeight;
    public Transform RightHandTarget;

    public Transform weapon;
    public Vector3 lookPos;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();

        weapon.position = RightHandTarget.position;
	}
	
	// Update is called once per frame
	void Update () {
		weapon.position = RightHandTarget.position;
	}

    private void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandWeight);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftHandWeight);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandTarget.rotation);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, RightHandWeight);
        anim.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, RightHandWeight);
        anim.SetIKRotation(AvatarIKGoal.RightHand, RightHandTarget.rotation);
    }
}
