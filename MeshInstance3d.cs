using Godot;
using hyprlandsuperwallpapertemplate.Scripts.Events;
using hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;
using hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes.ExampleCustomEvents;

namespace hyprlandsuperwallpapertemplate;

public partial class MeshInstance3d : MeshInstance3D
{
    private int _prevWorkspaceId = 0;
    private int _pendingWorkspaceId = 0;
    private float _pendingDirection = 0f;
    private Tween _tween;
    private float _rotationStep = Mathf.DegToRad(90); // 90 degrees in radians
    private float _duration = 0.5f; // seconds
    private bool _pendingLocked;

    public override void _Ready()
    {
        EventManager.Instance.Subscribe<WorkspaceV2Event>(OnWorkspaceChanged);
        EventManager.Instance.Subscribe<HyprlockStateEvent>(OnLockStateChanged);
        EventManager.Instance.StartAll();
    }
    
    
    private void OnWorkspaceChanged(WorkspaceV2Event args)
    {
        var newId = args.WorkspaceId;
        if (newId == _prevWorkspaceId)
            return;

        _pendingWorkspaceId = newId;
        _pendingDirection = newId > _prevWorkspaceId ? 1f : -1f;
        CallDeferred(nameof(AnimateRotation));
    }
    
    private void OnLockStateChanged(HyprlockStateEvent args)
    {
        _pendingLocked = args.Locked;
        CallDeferred(nameof(AnimateLockState));
    }
    
    private void AnimateLockState()
    {
        Vector3 targetPosition;
        float targetRotationX;

        if (_pendingLocked)
        {
            targetPosition = new Vector3(Position.X, 1f, -1f);
        }
        else
        {
            targetPosition = new Vector3(Position.X, 0f, 1f);
        }

        targetRotationX = Rotation.X + Mathf.DegToRad(180);

        _tween?.Kill();
        _tween = CreateTween();
        _tween.Parallel().TweenProperty(this, "position", targetPosition, _duration)
            .SetTrans(Tween.TransitionType.Quad)
            .SetEase(Tween.EaseType.Out);
        _tween.Parallel().TweenProperty(this, "rotation:x", targetRotationX, _duration)
            .SetTrans(Tween.TransitionType.Quad)
            .SetEase(Tween.EaseType.Out);
    }
    
    private void AnimateRotation()
    {
        float targetY = Rotation.Y + _pendingDirection * _rotationStep;
        _tween?.Kill();
        _tween = CreateTween();
        _tween.TweenProperty(this, "rotation:y", targetY, _duration)
            .SetTrans(Tween.TransitionType.Quad)
            .SetEase(Tween.EaseType.Out);

        _prevWorkspaceId = _pendingWorkspaceId;
    }

    public override void _ExitTree()
    {
        EventManager.Instance.Unsubscribe<WorkspaceV2Event>(OnWorkspaceChanged);
        _tween?.Kill();
    }
}