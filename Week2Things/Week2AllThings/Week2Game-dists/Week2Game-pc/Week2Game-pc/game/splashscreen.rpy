label splashscreen:
    $ persistent.win = "Default"
    
    show text "{color=#ffffff}Week2{/color}" with dissolveLong
    with Pause(2)

    hide text with dissolveShort
    with Pause(1)


    ##image main:
        ##"gui/main_menu.png"
        ##xalign 1.0
        ##linear 2.5 xpos 0.0
        ##repeat


    ##image menu_logo:
    ##    "gui/window_icon.png"
        ##subpixel True
    ##    xcenter 240
    ##    ycenter 120
##zoom 0.60
    ##    menu_logo_move

##    transform menu_logo_move:
    ##    subpixel True
    ##    yoffset -300
    ##    time 1.925
        ##easein_bounce 1.5 yoffset 0

    return
