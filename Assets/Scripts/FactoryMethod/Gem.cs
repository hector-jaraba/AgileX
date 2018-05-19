using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory{
    public class Gem : Reward
    {
        private BoxCollider2D boxCollider2D;

        protected override void AnimatorConfigurator()
        {
            string animation = "Animations/gem_0";
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animation);
        }

        private void BoxCollider2DConfigurator()
        {
            
            boxCollider2D.isTrigger = true;


        }

        protected override void SpriteRenderConfigure()
        {
            string sprite = "Sprites/gem";
            spriteRenderer.sprite = Resources.Load(sprite, typeof(Sprite)) as Sprite;
            spriteRenderer.sortingLayerName = "DECORADO";

        }

        protected override void CreateRewardComponents()
        {
            base.CreateRewardComponents();
            if (boxCollider2D == null)
            {
                boxCollider2D = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
                BoxCollider2DConfigurator();
            }
        }



        protected override void Awake()
        {
            base.Awake();
            gameObject.tag = "Gem";
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.tag == "Gem") {
                base.touchReward = true;
                Debug.Log(base.IsTouchingReward());
            }
        }

    }
}

