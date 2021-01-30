# The script of the game goes in this file.

# Declare characters used by this game. The color argument colorizes the
# name of the character.

## Make reader care about store

# The game starts here.

label start:

    ##player
    $ NoName = False

    ##characters
    $ reinaint = False
    $ miuint = False
    $ sakiint = False

    #$ e.lab += 0

    ##dialogue
    $ convo = False
    $ win = False

    ##lab
    $ lab = False
    $ labinfo = False
    $ seenlab = False

    ##easteregg
    $ Dumb = False

    stop music fadeout 3.0

    $ player = renpy.input("What is your name, Detective?")

    $ player = player.strip()

    if player == "":
        $ NoName = True
        $ player = "Cheese"

    if NoName == True:
        n "You didn't tell me your name, noted, I'll call you %(player)s then."

    scene black with wipeleft

    n "Hey %(player)s."

    n "Today we are going to find out who robbed the store."
    if persistent.played == True:
        menu:
            n "Quick question before we start, do you jump to conclusions a lot? (Easter Egg)"

            "Yes":
                n "Okay good to know."
                jump DumbGame
            "No":
                n "Okay good."
                jump Main
    else:
        jump Main

label DumbGame:
    $ Dumb = True
    jump Main

label Main:

    scene bg DormNight with openeyes

    queue music ["audio/backgroundmusic/OGG Dystopian by Tim Beek/Mystery Unsolved.ogg", interregation1]

    show saki sangry at left with Pause(1)

    show miu mcat with Pause(1)

    show reina rannoyed at right with Pause(1)

    n "These are our main suspects."

    n "The girl on the far left is Saki."

    n "The girl in the middle is Miu."

    n "And the girl on the right is Reina."

    n "Your job is to interrogate and find out who robbed the store."

    n "Okay remember your training and get to it."

##check if all have been spoken too
    jump check

##lab check

    label check:
        if reinaint == True & sakiint == True:
            $ lab = True
            jump check2
        else:
            jump check3

    label check2:
        if lab == True:
            if seenlab == True:
                jump check3
            if seenlab == False:
                jump labcall

    label checklabinfo:
        if labinfo == True:
            if reinaint == True & sakiint == True & miuint == True:
                n "You have already interrogated all of the suspects."
                n "And have all the information they have to offer."
                n "You need to accuse an individual now."
                jump end
            else:
                jump interrogate
        else:
            if reinaint == True & sakiint == True & miuint == True:
                jump end
            else:
                jump interrogate

## convo checks
    label check3:
        if reinaint == True:
            jump check4

        else:
            jump interrogate

    label check4:
        if sakiint == True:
            jump check5

        else:
            jump interrogate

    label check5:
        if miuint == True:
            jump end

        else:
            jump interrogate

##choice menu

    label interrogate:
        if convo == True:

            show saki sangry at left with Pause(1)

            show miu mcat with Pause(1)

            show reina rannoyed at right with Pause(1)

            mc "Who should I interrogate next?"

            jump interro

        if convo == False:

            mc "Who should I start with first?"

            jump interro

    label interro:

        if Dumb == False:

            menu:

                mc "I'll talk to...."

                "Saki":
                    if sakiint == True:
                        show saki sworried at left
                        s "Oh you've already talked to me."
                        jump interrogate
                    else:
                        $ interrogate = "Saki"
                        jump SakiIntStart

                "Miu":
                    if miuint == True:
                        show miu mpout
                        m "You have already talked to me, remember?"
                        jump interrogate
                    else:
                        $ interrogate = "Miu"
                        jump MiuIntStart


                "Reina":
                    if reinaint == True:
                        show reina rlaugh at right
                        r "You have already questioned to me."
                        jump interrogate
                    else:
                        $ interrogate = "Reina"
                        jump ReinaIntStart

                "Accuse Someone":
                    jump end

        if Dumb == True:
            show screen large_button
            show screen large_buttontwo
            $ result = ui.interact()

        if result == "Accuse":
            hide screen large_buttontwo
            hide screen large_button
            jump ending

##lab call
label NoLab:
        $ labinfo = False
        $ seenlab = True
        "Tom" "Oh okay, I'll leave you to it"
        "The phone goes dead."
        jump interrogate

label labcall:
    $ seenlab = True
    scene bg DormNight with wipeleft
    show saki sangry at left

    show miu mcat

    show reina rannoyed at right

    "Ring ring"
    pause(1)
    "It's the lab."
    "Forensic Scientist" "Hey it's Tom from the forensics team."
    "Tom" "We have found ground breaking evidence we need to disclose to you urgently."
    menu:
        "Tom" "Can we tell you now?"

        "Yes":
            pass
        "No":
            jump NoLab

    $ labinfo = True
    "Tom" "Okay great"
    "Tom" "We have found fingerprint evidence on some of the glass that was smashed."
    "Tom" "The fingerprints are from Reina."
    pause(1)
    mc "Woah"
    "Tom" "What's even more interesting is that there was a dropped pen that had fingerprints from Miu"
    "Tom" "And there was a can in the garbage bin nearby that had fingerprints from Saki"
    "Tom" "This means that they were all in the area at some point recently"
    mc "Okay thank you"
    $ seenlab = True

    menu:
        "Do you want to accuse now?"

        "Yes":
            jump ending
        "No":
            pass

    jump checklabinfo


##start interrogate

label ReinaIntStart:

    $ reinaint = True
    show reina rsmile
    mc "Reina, can I see you please? I have some questions to ask?"
    r "Sure thing!"

    $ convo = True
    jump ReinaInt

label SakiIntStart:

    $ sakiint = True
    show saki sworried
    mc "Saki can you come with me please?"
    s "Oh ok, s-sure."


    $ convo = True
    jump SakiInt

label MiuIntStart:
    $ miuint = True
    show miu msurprised
    mc "Miu can you-"
    show miu msad at namem
    m "Me?!"
    mc "Yes, come with me please I have a few questions."

    $ convo = True
    jump MiuInt

##main interrogate
##each character talks about what the others have done that day
##potential flashback sequence throughout the day of the murder? Drop hints at the main culprit (Reina)

label MiuInt:

    scene bg KitchenNight with wipeleft
    show miu mpout
    m "Why are you even questioning me? Give me a reason why."
    mc "You're a suspect so you are being questioned."

    show miu mneutral
    show bg parkstreet with fadeLongest

    m "I went to the park."
    m "I had to relax after an extremely hectic day."
    mc "What time was this?"
    m "Right after school."

    if reinaint == True: ##conflicting arguments, have Reina not back her up, Saki being stressed aswell about who to back
        m "I have also talked to Reina quite a bit too so she can verify me being stressed and me stating that I went to the park."

    if reinaint == False:
        m "Also I noticed you haven't spoken to Reina yet, she can verify that I went to the park."

    scene bg KitchenNight with wipeleft
    show miu mneutral
    mc "Okay so you went to the park, what else you get up to afterwards."
    show miu mpout
    m "{i}Ugh this is so annoying.{/i}"
    m "I then went to an aquarium actually."

    scene bg aquarium with wipeleft
    show miu mpout

    m "Yeah I decided to take a day out after school to wind down."
    m "Was thinking on where to go and stumbled on the aquarium."
    m "So just had a walk around there."
    pause(1)
    m "Was nice actually."

    scene bg KitchenNight with wipeleft
    show miu mpout

    mc "So what about the journey coming back from this place."
    m "Oh my days it isn't me."
    m "I'll answer anyway so you can verify it for yourself."

    scene bg cherry with wipeleft
    show miu mcat
    m "I just walked home."
    m "Full of cherry blossoms."
    m "It is a very nice road."

    scene bg KitchenNight with wipeleft
    show miu mpout
    m "Anything else?"

    if reinaint == True:
        menu:
            "Erm.."

            "What did Reina get up too?":
                pass
            "No, I have no more questions":
                scene bg DormNight with wipeleft
                jump check

    show miu msurprised
    m "Oh Reina."
    m "She wasn't here when I got home."
    show miu mcat
    m "She told me she was staying out until late to go see a friend."
    mc "Okay thanks for answering my questions."
    show miu mpout
    m "..."
    pause(1)
    scene bg DormNight with wipeleft
    jump check
    return

label SakiInt:

    scene bg KitchenNight with wipeleft
    show saki scurious
    s "Have I done something wrong?"
    mc "Ask yourself that."
    show saki sworried
    pause(1)
    mc "Do you think you have done something wrong?"
    s "N-no."
    show saki snormal
    mc "Why don't you tell me what you did on the day of the robbery?"
    show saki shappy
    s "Okay, so here's what happened."

    scene bg pool with fadeLongest
    show saki shappy

    s "I went to the pool."
    s "I did a few laps of the pool."
    s "And headed back home."
    scene bg KitchenNight with wipeleft
    show saki snormal

    menu:
        "Should I ask for more detail about her journey home?"

        "Yes":
            pass
        "No":
            jump check


    mc "Okay so what did you do on your way home? Describe the journey to me."
    s "Well..."
    scene bg Street with fadeLongest
    show saki sworried
    s "I walked home and stopped by a nearby store, not the store that was robbed though, this is a different one."
    s "I also stayed there for a little while and just watched the world go by for a little moment."
    s "Just listening to music and winding down."
    show saki snormal
    s "It was nice."
    scene bg KitchenNight with wipeleft
    show saki snormal
    s "So you got any more questions for me to answer?"

    menu:
        "Erm..."

        "Did you happen to see Reina or Miu on your way home?":
            pass
        "No that is all thanks":
            jump check

    s "No I didn't, sorry."
    scene bg DormNight with wipeleft
    jump check
    return

label ReinaInt:

    scene bg KitchenNight with wipeleft
    show reina rnormal
    mc "So how are you doing?"
    show reina rsmile
    r "Yeah I'm feeling fine, why are you questioning me anyway?"
    show reina rwink
    mc "Well maybe I have figured you out, or maybe I am ruling you out!"
    mc "What were you doing on the day of the robbery."
    show reina rnormal
    r "Oh I went to the park."

    show reina rsmile
    show bg parkstreet with fadeLongest

    r "I went to the park."
    r "I had to relax after an extremely busy day."
    mc "What time did you go?"
    r "Right after school"

    if miuint == True: ##conflicting arguments, have Reina not back her up, Saki being stressed aswell about who to back
        r "I also have talked to Miu too so she can verify me being stressed and me stating that I went to the park."

    if miuint == False:
        r "Also I noticed you haven't spoken to Miu yet, she can verify that I went to the park."

    scene bg KitchenNight with wipeleft
    show reina rnormal

    mc "What did you do while you were at the park?"
    show reina rsmile
    r "Oh I just had a walk around the place, sat down on a nearby bench, the usual winding down stuff."
    show reina rlaugh
    r "It was honestly really nice, I might try going there more often."
    show reina rsmile
    r "You should try going for regular walks too, eases the mind."
    mc "This is about you not me here."
    show reina rlaugh
    r "Sorry sorry"
    mc "So after you went to the park, what you get up to?"
    show reina rnormal
    r "Well..."

    scene bg phillipenes with wipeleft
    show reina rsmile
    r "I went to visit a friend."
    r "We planned this in advance to go hang out with each other since we don't get too see each other that much anymore."
    mc "Okay."
    mc "What did you guys get up to?"
    show reina rnormal
    r "Oh just kinda hanged out, watched TV, played some video games, stuff like that."
    mc "Okay."
    r "So you have anymore questions for me?"
    if miuint == True:
            menu:
                "Erm.."

                "What did Miu get up to?":
                    pass

                "No nothing else":
                    scene bg DormNight with wipeleft
                    jump check

    show reina rnormal
    r "Oh Miu?"
    pause(1)
    show reina rlaugh
    r "She also went for a walk but at a different park."
    show reina rsmile
    mc "Oh okay."
    mc "Want to ask anything else?"
    mc "No, nothing else."
    scene bg DormNight with wipeleft
    jump check
    return


##Ending

label end:

    show saki sangry at left

    show miu mcat

    show reina rannoyed at right

    "Ugh this is difficult."
    "No one has given me anything really damning."
    if reinaint == False or miuint == False:
        jump ending
    "I have had contradictory statements too from Miu and Reina though."
    mc "I have further questioning that I need to do."
    mc "This is between Miu and Reina."
    mc "Saki can you leave the room please?"
    s "Oh yeah sure thing."

    ##Reina and Miu joint interrogate

    show saki sangry at rightleave
    play sound opendoor
    pause(1)
    play sound closedoor
    "Saki leaves the room"

    show reina rannoyed at right
    show miu mneutral at left

    mc "So I have talked to you both separately."
    mc "And now I need to talk to you both together."
    mc "You have both went to the exact same park."

    show miu mpout at left
    show reina rlaugh at right

    mc "Can you explain why this is Miu?"
    m "Your blaming me!? Really?!"
    m "I've already explained why I went I had an extremely hectic day!"
    show reina rsmile at right
    show miu msad at left
    m "Do you want me to go in depth on this? Why it was hectic?!"

    menu:
        "Yes":
            jump Yes
        "No":
            jump No


label No:

    m "I'm telling you anyway I don't care about your choice! I'm innocent!"
    jump Yes

label Yes:

    m "I was stressed outta my mind from a day full of class after class after class where I did not understand a thing."
    m "So I had to stay behind for longer to revise the topics."

    menu:
        mc "Okay..."
        "What were the topics?":
            jump miutopic
        "Reina, what's your side?":
            jump ReinaMiu_ReinaSide


    label miutopic:
        show reina rnormal at right
        show miu mpout at left
        m "I don't even wanna talk about it because I just get nervous even referencing the topic because I'm struggling with it so much."
        show miu msad at left
        m "But the topic is Geography."
        m "Used to adore it but as of late I am really struggling with it."
        m "My teacher for Geography is not great and everyone in the class agrees."
        m "So I am practically teaching myself all the concepts."
        m "With no guidance or support."
        mc "I'm sorry to hear that, Reina what's your story?"
        jump ReinaMiu_ReinaSide

    label ReinaMiu_ReinaSide:
        show reina rannoyed at right
        show miu msad at left
        r "I don't get how you can lie like that at all."
        r "That's insane."
        show miu mpout at left
        show reina rlaugh at right
        m "What!?"
        mc "Miu you told your side let me hear Reina's please"
        show miu msad at left
        show reina rwink at right
        r "I told Miu that I was going to the park and I guess she is trying to frame me now."
        r "By taking my alibi and everything I said to her and confiding in her now taking what I said as what she did."
        show reina rnormal at right
        r "Effectively framing me making it seem that I am taking her alibi and making it seem I did not do what I actually did that day."
        r "I did literally everything she has said that day, {i} I {/i} was stressed out of my mind and had to stay behind to understand the concepts I did not understand."
        r "I went to the park that day."
        show reina rlaugh at right
        r "And I am indeed appalled that she would do this because I did not think it was any of us three and was bewildered that you wanted to talk to us this night."
        show reina rwink at right
        r "But I can see why now."
        show reina rnormal at right
        r "I am really upset and feeling betrayed here as your friend Miu."
        r "It's Miu, I did not suspect anyone here as the one who did it until now."
        if labinfo == True:
            menu:
                "Do you want to disclose the fingerprint evidence found?"

                "Yes":
                    pass
                "No":
                    jump notdisclosed

            show reina rannoyed at right
            show miu msad at left
            mc "Well I have something I did not tell you at the start"
            mc "That phone call earlier"
            mc "They stated they found fingerprints on the smashed glass"
            mc "And found fingerprints on a dropped pen near the store"
            mc "And fingerprints on a can in the garbage"
            mc "Were you near the store at all?"
            m "Yes..."
            show reina rlaugh at right
            show miu msurprised at left
            r "Uh-aha I was too"
            mc "Why did you withhold that information earlier?"
            show reina rannoyed at right
            mc "Is it to hide evidence?"
            show miu mpout at left
            m "No! You never asked!"
            r "Yeah!"
            show reina rnormal at right
            show miu msad at left
            mc "Well I would certainly think it is noteworthy to say I was nearby when being interrogated"#
            mc "Even more so if my fingerprints were on smashed glass, wouldn't you agree Reina?"
            show reina rnormal at right
            r "Huh?"
            mc "You smashed the glass didn't you?"
            show reina rannoyed at right
            r "What!? No! I must of had my hand on it looking into the shop window!"
            mc "Miu your fingerprints were near too"
            show miu msurprised at left
            mc "They were on a dropped pen nearby"
            show miu mpout at left
            m "That means literally nothing, it just means I dropped a pen"
            show reina rannoyed at right
            r "So you have heard what we have to say, What choice are you gonna make %(player)s?"
            jump notdisclosed
    label notdisclosed:
        "I think I should get Saki to help with this."
        "I think it is my only real option to help clarify things and it not be a 50/50 call."

        menu:
            "Should I do this?"

            "Ask Saki for help":
                pass
            "Make an accusation":
                jump ending

        mc "I'll be right back."
        scene bg KitchenNight with wipeleft
        show saki ssurprised
        s "Have you made your decision?"
        mc "I need your help with this."
        show saki sworried
        s "What?!"
        s "I can't do this! They are my friends!"
        mc "And you want the right one to be held accountable so the other one does not get wrongly accused right?"
        s "I don't want no one to be caught."
        mc "Well if you don't help me I'm going to be doing it myself and I may make the wrong decision and send one your innocent friends to jail."
        mc "Is that something your okay with?"
        s "N-no."
        mc "So are you going to help me then?"
        s "I-I guess I have no choice."
        mc "Alright come in the room then."
        scene bg DormNight with wipeleft
        show saki sworried
        show reina rnormal at right
        show miu mpout at left
        mc "Saki has agreed to help me with this decision."
        "Miu and Reina" "Saki!?"
        m "Are you kidding me Saki!?"
        s "I-I don't have a choice!"
        m "You do!"
        m "What have you said to her %(player)s!?"
        mc "None of your concern."
        if labinfo == True:
                mc "Saki"
                mc "Can you explain why I found Reina's fingerprints on some smashed glass from the robbed store?"
                show saki sworried at namem
                s "Wha-!?"
                s "How!?"
                s "I honestly do not know at all how that is there!"
                mc "Wow."
                mc "That's strange."
                mc "I mean you have been there right?"
                s "N-no."
                mc "Ahhh."
                mc "I found a can you threw away in a bin right next to the store."
                mc "Be honest with me Saki."
                show saki ssurprised
                mc "Don't withold information because I'm suspecting it might be you here."
                s "Ahh!"
                s "I'm sorry I'm just so scared!"
                mc "If you aren't witholding information or done the crime then you have no need to be worried."
                mc "Do you have a reason to be worried?"
                s "Do you think I have a reason to be?"
                mc "That's for you decide I may already have my suspicions on you, or on someone else."
                pause(1)
                mc "So Saki."
                mc "What do you think of the smashed glass fingerprints."
                s "I honestly don't know! Okay!?"
                s "I don't know how it got there!"
                pass
        if reinaint == True:
            mc "Also Saki where did Reina go yesterday?"
            s "Oh she went to the park."
            mc "Okay."
            pass
        if miuint == True:
            mc "Where did Miu go yesterday Saki?"
            if miuint == True and reinaint == True:
                s "Yeah she went to the park aswell"
                mc "Okay then."
                jump sakiend
            s "Yeah she went to the park."
            jump sakiend

    label sakiend:
        if reinaint == False and miuint == False and labinfo == False:
            mc "I don't really know what to ask of you"
            s "What?!"
            s "Why did you stress me out like this then!"
            mc "Erm..."
            pass

        r "So you have heard what we have to say, What choice are you gonna make %(player)s?"
        jump ending


label ending:

    if Dumb == True:
        n "Wow you weren't lying when you said you jumped to conclusions"

    if Dumb == False:
        pass

    menu:
        mc "I think it is..."

        "Reina":
            mc "Reina"
            $ persistent.win = "Reina"
            $ persistent.played = True
            jump winending

        "Miu":
            mc "Miu"
            $ persistent.win = "Miu"
            $ persistent.played = True
            jump miuending

        "Reina and Miu":
            mc "Reina and Miu"
            $ persistent.win = "ReinaMiu"
            $ persistent.played = True
            jump reinaandmiuending

        "Saki":
            mc "Saki"
            $ persistent.win = "Saki"
            $ persistent.played = True
            jump sakiending

        "All of you":
            mc "All of you"
            $ persistent.win = "AllOfYou"
            $ persistent.played = True
            jump All

        "None of you":
            mc "None"
            $ persistent.win = "None"
            $ persistent.played = True
            jump NoneOf

##lose conditions

label sakiending:
    mc "You've been caught Saki."
    play sound opendoor
    show saki sworried at enterinmid
    s "Oh my gosh! No! It's not me I swear!"

    scene black with fadeLongest
    stop music fadeout 3.0

    "I took Saki to the station."
    "Something tells me this was not the right person."

    return

label miuending:
    show miu msurprised
    mc "You've been caught Miu."
    m "What!?"

    scene black with fadeLongest
    stop music fadeout 3.0

    "I took Miu to the station."
    "Something tells me this was not the right person."

    return

label reinaandmiuending:
    show reina rannoyed
    mc "Miu and Reina you are being arrested on the charges of Robbery."
    "Miu and Reina" "What!?"

    scene black with fadeLongest
    stop music fadeout 3.0

    "I took Miu and Reina to the station."
    "Something tells me this is not the right decision."

    return

label All:
    show reina rannoyed
    show miu msad
    mc "All of you are being arrested on the charges of Robbery."
    "All" "What!?"

    scene black with fadeLongest

    "I took the three girls to the station."
    "Something tells me this is not the right decision."

    return

label NoneOf:
    show reina rnormal
    show miu mcat
    play sound opendoor
    show saki snormal at enterinmid

    mc "None of you."

    "Saki shouts from the other room"

    show saki shappy
    s "Yeah I knew it was none of us."

    scene black with fadeLongest
    "I promptly left the dorms."
    "Something tells me it is one of the girls, or potentially two of them or all of the girls."

    return

##win condition

label winending:

    show reina rannoyed
    mc "You've been caught Reina."
    r "Excuse me?"

    scene black with fadeLongest

    "I took Reina to the station."
    "Something tells me this is the right person."

    return
