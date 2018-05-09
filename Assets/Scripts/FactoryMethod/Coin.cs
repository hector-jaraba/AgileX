using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory{
    public class Coin : Reward {
        protected override void AnimatorConfigurator()
        {
            string animation = "Animations/moneda";
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animation);
        }

        protected override void CircleCollider2DConfigurator()
        {
            
        }

        protected override void SpriteRenderConfigure()
        {
            string sprite = "Sprites/moneda_0";
            spriteRenderer.sprite = Resources.Load<Sprite>(sprite);
        }

		// Use this for initialization
		void Start () {
            
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    	}


    }
}
