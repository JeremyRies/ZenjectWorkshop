namespace Assets.Scripts
{
    public interface IPlayerModel
    {
        IReadOnlyReactiveProperty<float> PlayerYPosition { get; }
    }
}
