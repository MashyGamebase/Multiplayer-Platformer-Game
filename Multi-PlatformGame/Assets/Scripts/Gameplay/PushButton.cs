using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PushButton : MonoBehaviour, IPunObservable
{
    public GameObject woodArrow;
    private bool isFlipped;

    Animator anim;

    PhotonView view;

    private void Start()
    {
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("ButtonPop");
            Flip();
        }
    }

    [PunRPC]
    private void Flip()
    {
        isFlipped = !isFlipped;
        Vector3 scale = woodArrow.transform.localScale;
        scale.x = isFlipped ? -1 : 1;
        woodArrow.transform.localScale = scale;
    }

    private void AddObservable()
    {
        if (!view.ObservedComponents.Contains(this))
        {
            view.ObservedComponents.Add(this);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(woodArrow.transform.localScale);
            stream.SendNext(isFlipped);
        }
        else
        {
            woodArrow.transform.localScale = (Vector3)stream.ReceiveNext();
            isFlipped = (bool)stream.ReceiveNext();
        }
    }
}