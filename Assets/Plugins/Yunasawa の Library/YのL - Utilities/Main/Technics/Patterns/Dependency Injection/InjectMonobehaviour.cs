#if DEPENDENCY_INJECTION
using ImpossibleOdds.DependencyInjection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace YNL.Pattern.DependencyInjection
{
    [Injectable]
    public class InjectMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            DependencyInjector.Inject(GlobalDependencyScope.GlobalScope.DependencyContainer, this);
            DependencyInjector.Inject(DependencyConfig.CurrentSceneScope.DependencyContainer, this);
        }
    }

    [Injectable]
    public class InjectSerializedMonoBehaviour : SerializedMonoBehaviour
    {
        protected virtual void Awake()
        {
            DependencyInjector.Inject(GlobalDependencyScope.GlobalScope.DependencyContainer, this);
            DependencyInjector.Inject(DependencyConfig.CurrentSceneScope.DependencyContainer, this);
        }
    }
}
#endif