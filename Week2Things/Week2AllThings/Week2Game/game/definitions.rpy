##definitions
define s = Character("Saki") ##passive/shy
define m = Character("Miu") ##aggro
define r = Character("Reina") ##confident

define n = Character("Narrator")
define character.mc = Character('[player]')

##image colour

image white = "#fff"
image black = "#000"

##characters

##saki

image saki sangry = im.FactorScale("images/sprites/saki/saki_angry.png", 0.2)
image saki ssurprised = im.FactorScale("images/sprites/saki/saki_surprised.png", 0.2)
image saki snormal = im.FactorScale("images/sprites/saki/saki_normal.png", 0.2)
image saki shappy = im.FactorScale("images/sprites/saki/saki_happy.png", 0.2)
image saki scurious = im.FactorScale("images/sprites/saki/saki_curious.png", 0.2)
image saki sworried = im.FactorScale("images/sprites/saki/saki_worried.png", 0.2)


##reina
image reina rannoyed = im.FactorScale("images/sprites/reina/reina_annoyed.png", 0.2)
image reina rwink = im.FactorScale("images/sprites/reina/reina_wink.png", 0.2)
image reina rlaugh = im.FactorScale("images/sprites/reina/reina_laugh.png", 0.2)
image reina rnormal = im.FactorScale("images/sprites/reina/reina_normal.png", 0.2)
image reina rsmile = im.FactorScale("images/sprites/reina/reina_smile.png", 0.2)


##Miu

image miu mcat = im.FactorScale("images/sprites/miu/miu_catsmile.png", 0.2)
image miu mneutral = im.FactorScale("images/sprites/miu/miu_neutral.png", 0.2)
image miu mpout = im.FactorScale("images/sprites/miu/miu_pout.png", 0.2)
image miu msad = im.FactorScale("images/sprites/miu/miu_sad.png", 0.2)
image miu msurprised = im.FactorScale("images/sprites/miu/miu_surprised.png", 0.2)

##background images

##home
image bg DormDay = "images/backgrounds/Modern Background Set by Konett/Modern-Dormroom1.png"
image bg DormEve = "images/backgrounds/Modern Background Set by Konett/Modern-Dormroom2.png"
image bg DormNight = "images/backgrounds/Modern Background Set by Konett/Modern-Dormroom3.png"
image bg School = "images/backgrounds/Modern Background Set by Konett/Modern-School1.png"
image bg Street = "images/backgrounds/Modern Background Set by Konett/Modern-Street1.png"
image bg KitchenNight = "images/backgrounds/pack1/Assorted/kitchen_night.webp"

##flashbacks Reina and Miu
image bg parkstreet = "images/backgrounds/pack1/Modern Urban/parkstreet.webp"

##flashbacks Reina
image bg phillipenes = "images/backgrounds/pack1/Tropical Residence/philippines_002_afternoon copy.webp"

##flashbacks Miu

image bg aquarium = "images/backgrounds/pack2/Nature Too/aquarium.webp"
image bg cherry = "images/backgrounds/pack1/Modern Urban/lets_pretend_they_are_cherry_blossom.webp"

##flashbacks Saki

image bg pool = "images/backgrounds/pack1/Modern Urban/pool_afternoon_or_early_morning_depending_on_your_mood.webp"

##UI

image UIMain = "images/UI/paper-plain.png"


##sfx

define sound.opendoor = "game/audio/sfx/opendoor.mp3"
define sound.closedoor = "game/audio/sfx/closedoor.mp3"

##menusfx

define sound.ButtonClick = "game/audio/sfx/multi-plier-close-1.wav"
define sound.ButtonHover = "game/audio/sfx/button-19.wav"

##background music originaly going to have music for each segment
##but since the segments are quite small i feel the shift in one music's scene to the next might be quite jarring so went with a cycle instead

define audio.mainmenumusic = "audio/backgroundmusic/mainmenu.mp3"

define audio.interregation1 = "audio/backgroundmusic/Free BGM Package 1/Possibility V2.mp3"

define audio.interregation2 = "audio/backgroundmusic/OGG Dystopian by Tim Beek/Mystery Unsolved.ogg"
