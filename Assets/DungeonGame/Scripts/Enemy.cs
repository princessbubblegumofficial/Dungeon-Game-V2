using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Enemie:MonoBehaviour
{
    public string nome;
    public float speed;
    public float vida;
    public float maxvida;
    public Transform target;

    void Start()
    {
        vida = maxvida;
        Introduction();
    }
    void Introduction()
    {
        Debug.Log("meu nome � " + nome + "minha vida � " + vida + "e o maximo da vida �" + maxvida);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards
            (transform.position,target.position, speed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }

}
