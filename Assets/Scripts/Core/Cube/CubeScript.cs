using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeScript : MonoBehaviour
{
    public int cubeNumber;
    public TextMeshPro cubeText;
    public SpriteRenderer cubeSpriteRenderer;
    public Renderer tmproTextRenderer;
    

    private void Start()
    {
        tmproTextRenderer.sortingOrder = 2;
        cubeNumber = Random.Range(1, 100);
        cubeText.text = cubeNumber.ToString();
        CubeColorChange();
    }

    public void CubeColorChange()
    {
        if (cubeNumber <= 10)
        {
            cubeSpriteRenderer.color = Color.blue;
        }
        else if (cubeNumber > 10 && cubeNumber <= 30)
        {
            cubeSpriteRenderer.color = Color.green;
        }
        else if (cubeNumber > 30 && cubeNumber <= 50)
        {
            cubeSpriteRenderer.color = Color.red;
        }
        else
        {
            cubeSpriteRenderer.color = Color.cyan;
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (cubeNumber >= 1)
            {
                cubeNumber--;
                cubeText.text = cubeNumber.ToString();
                CubeColorChange();
            }
            else if (cubeNumber == 0)
            {
                //Destroy(gameObject);
            }

        }
    }
}
