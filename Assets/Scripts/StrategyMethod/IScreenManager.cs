using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IScreenManager
{
    void Active();
    void Retry();
    void Quit(string to);

}
