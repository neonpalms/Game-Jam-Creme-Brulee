using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Text))]
public class ScoreFXTextBehavior : MonoBehaviour
{
    #region Fields
    public GameBoardBehavior board;
    #endregion

    #region Members
    private Text _text;
    private Animator _anim;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _text = GetComponent<Text>();
        _anim = GetComponent<Animator>();
        if (board == null)
        {
            throw new MissingReferenceException(string.Format("Please assign the {0} field in the inspector.", nameof(board)));
        }
        board.OnPointsAwarded += PlayUIAnim;
    }
    #endregion

    #region Methods
    public void PlayUIAnim(int points)
    {
        _anim.SetTrigger("MatchMade");
        _text.text = string.Format("+{0}", points);
    }
    #endregion
}
