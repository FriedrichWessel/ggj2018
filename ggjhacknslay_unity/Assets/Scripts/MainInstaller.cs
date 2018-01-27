using Zenject;

public class MainInstaller : MonoInstaller
{
	public PlayerCamera PlayerCam;
	
	public override void InstallBindings()
	{
		Container.DeclareSignal<NewWalkTargetSignal>();
		Container.DeclareSignal<KeyPressedSignal>();
		Container.DeclareSignal<TargetAquiredSignal>();
		Container.DeclareSignal<GameStartSignal>();
		Container.DeclareSignal<GameOverSignal>();
		Container.Bind<TaskSystem>().AsSingle();
		Container.Bind<ITickable>().To<InputSystem>().AsSingle().NonLazy();
		Container.Bind<ITickable>().To<TaskSystem>().AsSingle().NonLazy();
		Container.Bind<IPlayerCamera>().FromInstance(PlayerCam).AsSingle();
	}
}
