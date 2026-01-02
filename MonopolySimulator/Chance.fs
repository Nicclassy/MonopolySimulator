namespace MonopolySimulator.Mechanics

open MonopolySimulator.Types

type ChanceCard = {
    Description: string
    Action: Board -> PlayerState -> PlayerState
}

module ChanceCards =
    let moveTo (spaceId : SpaceId) =
        let action (board : Board) (playerState : PlayerState) =
            let space = board.[spaceId]
            let position = board.PositionOf space
            { playerState with MovementState = NextPosition position }
        action

    let deck: ChanceCard list = [
        {
            Description = "Advance to Go (Collect $200)"
            Action = moveTo SpaceId.Go
        }
    ]

type ChanceCards(cards: ChanceCard list) =
    let cards = cards
    new () = ChanceCards ChanceCards.deck 