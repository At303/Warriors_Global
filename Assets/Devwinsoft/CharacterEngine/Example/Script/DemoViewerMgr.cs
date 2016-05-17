using UnityEngine;
using System.Collections;

namespace Devwin
{
    public class DemoViewerMgr : BaseViewerMgr
    {
        void Start()
        {
            base.prefix = "Demo";
            base.OnStart();
        }
    }
}
