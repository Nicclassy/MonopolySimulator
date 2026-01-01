namespace MonopolySimulator.Types

type UpgradeState = 
    | None
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

type JailedState = 
    | NotJailed
    | Jailed of turns : TurnsJailed
with
    static member Initial = Jailed NoTurns

type StreetState = {
    Upgrades: UpgradeState
}

type PlayerInventory = {
    mutable Money: uint
    mutable Purchases: StreetState list
} with
    static member Initial = { Money = 0u; Purchases = [] }

type PlayerState = {
    mutable Position: uint
    mutable Inventory: PlayerInventory
    mutable JailedState: JailedState
} with
    static member Initial = { 
        Position = 0u
        Inventory = PlayerInventory.Initial
        JailedState = NotJailed
    }