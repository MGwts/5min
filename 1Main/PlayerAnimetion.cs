using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{
	public static readonly string[] staticDirections = {"Aniplayer_stop_u", "Aniplayer_stop_l", "Aniplayer_stop_d", "Aniplayer_stop_r" };
	public static readonly string[] runDirections = { "Aniplayer_u", "Aniplayer_l", "Aniplayer_d", "Aniplayer_r" };

	Animator animator;
	int lastDirection;

	private void Awake()
	{
		//cache the animator component
		animator = GetComponent<Animator>();
	}

	public void SetDirection(Vector2 direction)
	{
		string[] directionArray = null;

		if (direction.magnitude < .01f){
			directionArray = staticDirections;

		}else{
			directionArray = runDirections;
			lastDirection = DirectionToIndex(direction, 4);    //�ǂ̃A�j���[�V�������Đ����邩�𔻒f
		}

		animator.Play(directionArray[lastDirection]);
	}

	public static int DirectionToIndex(Vector2 dir, int sliceCount)
	{
		Vector2 normDir = dir.normalized;    //normalized=���K��
		float step = 360f / sliceCount;    //�A�j���[�V������ς���p�x���v�Z���Ă�
		float halfstep = step / 2;
		float angle = Vector2.SignedAngle(Vector2.up, normDir);
		angle += halfstep;

		if (angle < 0)
		{
			angle += 360;
		}

		float stepCount = angle / step;
		return Mathf.FloorToInt(stepCount);
	}

}
