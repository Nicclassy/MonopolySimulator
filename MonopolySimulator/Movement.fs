namespace MonopolySimulator.Mechanics

open MonopolySimulator.Types

type RollResult = {
    DiceOne: uint
    DiceTwo: uint
    JailedState: JailedState
    RollAgain: bool
}

type Dice() =
    let mutable rolls = 0
    static let minRoll = 1
    static let maxRoll = 6
    static let randomDiceNumber () = System.Random.Shared.Next(minRoll, maxRoll)

    member _.Roll() =
        rolls <- rolls + 1
        let firstDiceNumber = randomDiceNumber()
        let secondDiceNumber = randomDiceNumber()
        let rollIsDouble = firstDiceNumber = secondDiceNumber
        { 
            DiceOne = uint firstDiceNumber
            DiceTwo = uint secondDiceNumber
            JailedState = if rolls = 3 then JailedState.Initial else NotJailed
            RollAgain = rollIsDouble
        }

