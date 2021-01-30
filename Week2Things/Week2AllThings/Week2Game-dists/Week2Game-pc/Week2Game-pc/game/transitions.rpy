##transitions

##Character appearing



##dissolve

define dissolveShort = Dissolve(0.25)

define dissolveMedium = Dissolve(0.50)

define dissolveLong = Dissolve(0.75)

define dissolveLongest = Dissolve(1.00)

##fades

define fadeShort = Fade(0.25, 0.25, 0.25, color = "#fff")

define fadeMedium = Fade(0.50, 0.50, 0.50, color = "#fff")

define fadeLong = Fade(0.75, 0.75, 0.75, color = "#fff")

define fadeLongest = Fade(1.00, 1.00, 1.00, color ="#fff")

##waking up

define openeyes = MultipleTransition([
    False, dissolveMedium,
    Solid("#fff"), Pause(0.25),
    True])

define closeeyes = MultipleTransition([
    False, dissolveMedium,
    Solid("#000"), Pause(0.25),
    True])

##wipescenes

define wiperight = CropMove(1.0, "wiperight")
define wipeleft = CropMove(1.0, "wipeleft")
define wipeup = CropMove(1.0, "wipeup")
define wipedown = CropMove(1.0, "wipedown")

##flicker

define flash = Fade(0.10, 0.10, 0.10, color ="#fff")

##hop

init:
    transform namel:
        linear 0.2 xalign 0.0 ypos 720
        linear 0.2 xalign 0.0 ypos 700
        
    transform namem:
        linear 0.2 xalign 0.5 ypos 720
        linear 0.2 xalign 0.5 ypos 700

    transform namer:
        linear 0.2 xalign 1.0 ypos 720
        linear 0.2 xalign 1.0 ypos 700

##leaving animations

init:
    transform rightleave:
        linear 0.5 xalign 2.5
    transform leftleave:
        linear 0.5 xalign -1.0

##entering animations

init:
    transform enterinmid:
        linear 0.5 xalign 0.5
    transform enterinleft:
        linear 0.5 xalign 0.0
    transform enterinright:
        linear 0.5 xalign 1.0

##animated menu

#show logo base:
#    xalign 0.0
#    linear 1.0 xalign 1.0
#    linear 1.0 xalign 0.0
#    repeat
