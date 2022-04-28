using TMPro;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro cubeText;
    [SerializeField] private AudioClip cubeSfxAudioClip;
    [SerializeField] private Renderer tmproTextRenderer;
    [SerializeField] private SpriteRenderer cubeSpriteRenderer;
    private Spawner spawnerScript;
    public int cubeNumber;
    
    

    private void Start()
    {
        spawnerScript = FindObjectOfType<Spawner>();
        tmproTextRenderer.sortingOrder = 2;
        CubeColorChange();
    }

    public void UpdateCubeNumber(int number)
    {
        cubeNumber = number;
        cubeText.text = cubeNumber.ToString();
    }

    public void CubeColorChange()
    {
        if (cubeNumber <= 10)
        {
            cubeSpriteRenderer.color = new Color(254f/255f, 206f/255f, 171f/255f);
        }
        else if (cubeNumber > 10 && cubeNumber <= 30)
        {
            cubeSpriteRenderer.color = new Color(220f/255f, 237f/255f, 194f/255f);
        }
        else if (cubeNumber > 30 && cubeNumber <= 50)
        {
            cubeSpriteRenderer.color = new Color(255f/255f,170f/255f,166f/255f);
        }
        else
        {
            cubeSpriteRenderer.color = new Color(229f/255f, 252f/255f, 194f/255f);
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (cubeNumber > 1)
            {
                cubeNumber--;
                AudioManager.instance.PlaySfx(cubeSfxAudioClip);
                cubeText.text = cubeNumber.ToString();
                CubeColorChange();
            }
            else if (cubeNumber == 1)
            {
                CubeObjectPooling.Instance.ReturnToPool(this);
                spawnerScript.RemoveCube(this);
            }

        }
    }
    
}
