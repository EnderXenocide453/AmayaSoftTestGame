using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GridManagement.DIContainer
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private GridExecutionHandler m_GridExecutionHandler;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(m_GridExecutionHandler);
        }
    }
}

