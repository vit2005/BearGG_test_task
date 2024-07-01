public interface IEnemyBehavior 
{
    void Init(IBehaviorData data);

    void OnUpdate();

    void OnRevive();
}

public interface IBehaviorData { }