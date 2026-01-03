namespace MonopolySimulator.Types

type UpgradeState = 
    | Mortgaged
    | Untouched
    | OneHouse
    | TwoHouses
    | ThreeHouses
    | FourHouses
    | Hotel

type TurnsJailed =
    | NoTurns
    | OneTurn
    | TwoTurns
with
    member this.Advance = 
        match this with
        | NoTurns -> OneTurn
        | OneTurn | TwoTurns -> TwoTurns

type StreetState = {
    Upgrades: UpgradeState
}

type PlayerInventory = {
    Money: uint
    Purchases: StreetState list
} with
    static member Initial = { 
        Money = 1500u
        Purchases = [] 
    }

type MovementState =
    | Default
    | PassedGo

type PlayerState = {
    Character: Character
    Position: uint
    MovementState: MovementState
    Inventory: PlayerInventory
    PassedGo: bool
} with
    static member Initial character = {
        Character = character
        Position = 0u
        MovementState = Default
        Inventory = PlayerInventory.Initial
        PassedGo = false
    }

type JailedPlayerState = {
    State: PlayerState
    TurnsJailed: TurnsJailed
}

type PlayerTurnState =
    | NotInJail of state : PlayerState
    | InJail of state : JailedPlayerState