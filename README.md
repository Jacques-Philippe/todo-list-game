# Purpose
The purpose of this project will be to try and establish a flow for indie game dev.

I want to try the following:
1. Document all of the following 
1. Create a game story using some online tool
1. Create art assets inspired by the story
    - inspiration artwork
    - music
1. Create a game from the story
1. Create a dev log after the game is finished and set the release schedule to be once a week
1. Flesh out the story, try writing a short story

# Missing Features
- [x] player position setting properly in scene loading
- [ ] story-driven notification (as opposed to dialog)
- [ ] visual feedback for which things are interactable
- [ ] pause menu

# Research
I had to learn some things to make this project
## Game story writing software
I used [Twine](https://twinery.org/cookbook/index.html) for the game story writing, as I needed a free, easy-to-use tool that would allow me to write divergent story paths. Games which have resonated strongly with me recently are more games from the 2000s and 2010s, where player choice had a significant impact on the story, so a tool that allows for different story paths was important to me.
## Music software
Garage band
    - Hard to find piano 03 loop?
## Video editing software

# Concepting
## Dialog
Given the player interacts with an NPC we expect the following
1. the NPC says something to the player and may expect a response
1. the player selects a response, and given that response the NPC will answer with something else
1. the player may also choose to simply leave

```
//choosing an answer
                    NPC: How are you?
Player      Good                Bad                               

NPC         I'm glad!           Tough cookies!
```

So if the NPC expects a response, then the NPC's following phrase will depend on the player's choice.

In addition, if the dialog is too long, we should be able to break it up into segments. So for instance, if there's some three line segment, and we want to break it into lines 1, 2, and 3, we should be able to cycle through those segments before we start to expect whatever comes next.

With respect to data structure we can say a Conversation is made up of a series of Phrases, which are spoken by given Members. A difference to be noted, however is that the player may have a list of possible options to choose from, whereas the NPC definitely doesn't.
```
Conversation
    Phrase first
    Phrase Current

    void Select(Phrase phrase)
    Phrase GetCurrentPhrase()

abstract Phrase
    Member member //who is talking
    Content content //the thing they're saying (UI is responsible for breaking this up)

    abstract 

PlayerPhrase : Phrase
    Phrase[] options    

NPCPhrase : Phrase 
    Phrase? next
```
### v0
1. The player interacts, the conversation is started
1. The conversation UI displays the next phrase to display (we can use the console for now)
```
abstract ConversationUI
    private Conversation conversation

    abstract void UpdateConversationUI(string toDisplay)

    void Start//subscribe to player interacted event

    void Open(Phrase)

ConsoleConversationUI
    override void UpdateConversationUI
        //log to console


PlayerInteraction
    public Action PlayerInteracted;

    void Update//listen for key press
```

# Figma
https://www.figma.com/file/vgwVfaAnaWA0zupGhM4iaT/Pilot?type=design&node-id=1%3A2&mode=design&t=QGz5WHtz1p4wSNJZ-1