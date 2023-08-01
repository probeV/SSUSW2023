using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
 
}

class _Object
{
    protected string[] txt=new string[5];
    protected string[] selection;

    public _Object() { }

    public _Object(string txt)
    {
        this.txt[0] = txt;
    }
    public _Object(string txt, string[] selection)
    {
        this.txt[0] = txt;
        this.selection = selection;
    }
    public _Object(string[] txt, string[] selection)
    {
        this.txt = txt;
        this.selection = selection;
    }
}

class ObjectSecurityOfficeDoor : _Object
{
    bool isSolved = false;

    public ObjectSecurityOfficeDoor(string[] txt)
    {
        this.txt = txt;
    }
}

class ObjectExitDoor : _Object
{
    bool isSolved = false;

    public ObjectExitDoor(string txt) : base() { }

    bool IsSolved()
    {
        return isSolved;
    }
}

