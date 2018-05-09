using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public abstract class Reward : MonoBehaviour
    {

        private int _points;

        public int GetPoints()
        {
            return _points;
        }

        public void SetPoints(int points)
        {
            this._points = points;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
