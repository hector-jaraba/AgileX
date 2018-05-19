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
            circleCollider2D.radius = 0.1828571f;

            
        }

        protected override void SpriteRenderConfigure()
        {
            string sprite = "Sprites/moneda";
            spriteRenderer.sprite = Resources.Load(sprite, typeof(Sprite)) as Sprite;
            Debug.Log("Sprite añadido");

            Debug.Log(this.spriteRenderer);

        }

		// Use this for initialization
		void Start () {
            

    		
    	}

        protected override void OnTriggerEnter2D(Collider2D collision)
		{
            base.OnTriggerEnter2D(collision);
		}


		private void Awake()
		{
            CreateRewardComponents();
            SpriteRenderConfigure();
            CircleCollider2DConfigurator();
            AnimatorConfigurator();
            gameObject.tag = "Coin";
		}

		// Update is called once per frame
		void Update () {

            //Debug.Log(GetComponent<SpriteRenderer>().sprite);
    		
    	}


    }
}
