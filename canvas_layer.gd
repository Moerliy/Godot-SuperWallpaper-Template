extends CanvasLayer

func _process(delta):
    var fps = Engine.get_frames_per_second()
    $FPSLabel.text = "FPS: %d" % fps