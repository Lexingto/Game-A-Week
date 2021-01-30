screen large_button():

    tag button_screen

    modal True
    vbox:
        textbutton "Saki" xalign 0.5 xpos 500 ypos 200 action Return("Saki")
        textbutton "Miu" xalign 0.5 xpos 500 ypos 200 action Return("Miu")
        textbutton "Reina" xalign 0.5 xpos 500 ypos 200 action Return("Reina")

style large_vbox is vbox

style large_vbox:
    xalign 0.5
    ypos 500
    yanchor 0.5

transform hello_t:
    align (0.7, 0.5) alpha 0.0
    linear 0.5 alpha 1.0

screen large_buttontwo():
    tag Accuse_Screen

    modal True
    textbutton "Accuse Someone" xalign 0.5 xpos 500 ypos 300 action Return("Accuse"):
        at transform:
            xpos 500
            ypos 300
            linear 10.5 zoom 10
