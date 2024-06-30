public interface IEnemyBehavior 
{
    void Init(IBehaviorData data);

    void OnUpdate();
}

public interface IBehaviorData { }