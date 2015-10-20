using Zenject;

public class MainInstaller : MonoInstaller
{
    public Game game;

    public override void InstallBindings()
    {
        Container.Bind<IGame>().ToInstance(game);
    }
}