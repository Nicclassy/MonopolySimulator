namespace MonopolySimulator.Mechanics

open MonopolySimulator.Types

type GameState(players: Player array) =
    let mutable players = players
    let mutable playerStatesByCharacter = 
        players
        |> Array.map (fun player -> player.Character, PlayerState.Initial)
        |> Map.ofArray

    member _.Item
        with get(index: Character) = playerStatesByCharacter.[index]

module GameMechanics =
    let nextPlayerPosition state (board : Board) { DiceOne = diceOne; DiceTwo = diceTwo } = 
        (state.Position + diceOne + diceTwo) % board.Length

    let playerAction playerState board = ()

    let jailedPlayerTurn playerState board = 
        let dice = Dice()
        let { RollAgain = escapedJail} as roll = dice.Roll()
        match playerState.JailedState with
        | _ when escapedJail ->
            // Do all in same place???~
            playerState.Position <- nextPlayerPosition playerState board roll
            playerAction playerState board
        | Jailed TwoTurns ->
            playerState.Position <- nextPlayerPosition playerState board roll
            playerAction playerState board
        | Jailed turns -> 
            playerState.JailedState <- Jailed turns.Advance
        | _ -> ()

    let playerTurn playerState board = 
        let mutable turnEnded = false
        let dice = Dice()
        while not turnEnded do
            let roll = dice.Roll()
            playerState.Position <- nextPlayerPosition playerState board roll 
            playerAction playerState board
            turnEnded <- not roll.RollAgain
            if roll.JailedState = JailedState.Initial then
                playerState.JailedState <- JailedState.Initial
                turnEnded <- true

    let PlayerTurn playerState board = 
        match playerState.JailedState with
        | Jailed _ -> jailedPlayerTurn playerState board
        | NotJailed -> playerTurn playerState board

