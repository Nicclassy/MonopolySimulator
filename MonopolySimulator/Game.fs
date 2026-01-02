namespace MonopolySimulator.Mechanics

open MonopolySimulator.Types

type GameState(players: Player array) =
    let players = players
    let playerStatesByCharacter = 
        players
        |> Array.map (fun player -> player.Character, PlayerState.Initial player.Character)
        |> Map.ofArray

    member _.Item
        with get(index: Character) = playerStatesByCharacter.[index]

module GameMechanics =
    let movePlayer (board : Board) { DiceOne = diceOne; DiceTwo = diceTwo } state = 
        let rawPosition = state.Position + diceOne + diceTwo
        let passedGo = rawPosition >= board.Length
        let position = rawPosition % board.Length
        { state with Position = position; PassedGo = passedGo }

    let playerAction (board : Board) (playerState : PlayerState) = 
        let space = board.[playerState.Position]
        playerState

    let jailedPlayerTurn ({ State = playerState } as jailedPlayerState : JailedPlayerState) board = 
        let escapeJail roll = 
            playerState 
                |> movePlayer board roll 
                |> playerAction board

        let { RollAgain = escapedJail} as roll = Dice.Roll()
        match jailedPlayerState.TurnsJailed with
        | _ when escapedJail ->
            escapeJail roll |> NotInJail
        | TwoTurns ->
            escapeJail roll |> NotInJail
        | turns -> 
            InJail { jailedPlayerState with TurnsJailed = turns.Advance }

    let playerTurn board playerState = 
        let dice = Dice()
        let rec turn () = 
            match dice.Roll() with 
            | Jailed -> 
                InJail { 
                    State = playerState
                    TurnsJailed = NoTurns
                }
            | Roll roll ->
                let playerState = 
                    playerState 
                    |> movePlayer board roll 
                    |> playerAction board

                if roll.RollAgain then
                    NotInJail playerState
                else
                    turn ()   
        turn ()
                
    let PlayerTurn (board : Board) playerTurnState = 
        match playerTurnState with
        | InJail jailedPlayerState -> jailedPlayerTurn jailedPlayerState board
        | NotInJail playerState -> playerTurn board playerState

