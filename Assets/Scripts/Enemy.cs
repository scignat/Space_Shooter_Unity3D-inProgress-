using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   // Start is called before the first frame update
   
    public float _speed = 4.0f;

    public Player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //if bottom of screen 
        //respawn at top with a new random position
        if(transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8);
            transform.position = new Vector3(randomX, 7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }


            Destroy(this.gameObject);
        }

 
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.Addscore(10);
            }
            Destroy(this.gameObject);
        }
    }
}
