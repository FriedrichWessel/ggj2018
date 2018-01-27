using Zenject;

public class MainInstaller : MonoInstaller
{
	public PlayerCamera PlayerCam;
	
	public override void InstallBindings()
	{
		Container.DeclareSignal<NewWalkTargetSignal>();
		Container.DeclareSignal<KeyPressedSignal>();
		Container.Bind<ITickable>().To<InputSystem>().AsSingle().NonLazy();
		Container.Bind<IPlayerCamera>().FromInstance(PlayerCam).AsSingle();
	}
}
