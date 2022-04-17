using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView :IviewUpdate
{
    void Init();
    void Show();
    void Hide();
}
