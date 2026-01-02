namespace MonopolySimulator.Mechanics

type Roll = {
    DiceOne: uint
    DiceTwo: uint
    RollAgain: bool
}

type RollResult = 
    | Roll of roll : Roll
    | Jailed


type Dice() =
    let mutable rolls = 0
    static let minRoll = 1
    static let maxRoll = 6
    static let randomDiceNumber () = 
        System.Random.Shared.Next(minRoll, maxRoll) |> uint

    static member Roll() = 
        let firstDiceNumber = randomDiceNumber()
        let secondDiceNumber = randomDiceNumber()
        let rollIsDouble = firstDiceNumber = secondDiceNumber
        { 
            DiceOne = firstDiceNumber
            DiceTwo = secondDiceNumber
            RollAgain = rollIsDouble
        }

    member _.Roll() =
        rolls <- rolls + 1
        let { RollAgain = rollIsDouble} as roll = Dice.Roll()
        let playerGoesToJail = rollIsDouble && rolls = 3
        if playerGoesToJail then Jailed else Roll roll
            
