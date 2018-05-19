using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory{
    public class Coin : Reward {

        private CircleCollider2D circleCollider2D;

        protected override void AnimatorConfigurator()
        {
            string animation = "Animations/moneda";
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animation);
        }

        private void CircleCollider2DConfigurator()
        {
            circleCollider2D.radius = 0.1828571f;
            circleCollider2D.isTrigger = true;
        }

        protected override void SpriteRenderConfigure()
        {
            string sprite = "Sprites/moneda";
            spriteRenderer.sprite = Resources.Load(sprite, typeof(Sprite)) as Sprite;
            spriteRenderer.sortingLayerName = "DECORADO";

        }

        protected override void CreateRewardComponents() {
            base.CreateRewardComponents();
            if (circleCollider2D == null)
            {
                circleCollider2D = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
                CircleCollider2DConfigurator();
            }
        }
        


		protected override void Awake()
		{
            base.Awake();
            gameObject.tag = "Coin";
		}

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.tag == "Coin")
            {
                base.touchReward = true;
            }
        }


    }
}
