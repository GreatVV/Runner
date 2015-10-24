using Zenject;

public class MainInstaller : MonoInstaller
{
    public Game game;
    public Character Character;
    public World World;
    public ClickControl ClickControl;

    public override void InstallBindings()
    {
        Container.Bind<IWorld>().ToInstance(World);
        Container.Bind<IControl>().ToInstance(ClickControl);
        Container.Bind<AMover>().ToSingle<ConstantSpeedMover>();
        Container.Bind<ICharacter>().ToInstance<Character>(Character);
        Container.Bind<IGame>().ToInstance(game);
    }
}