namespace MonopolySimulator.Mechanics

open MonopolySimulator.Types

type ChanceCard = {
    Description: string
    Action: Board -> PlayerState -> PlayerState
}

module ChanceCards =
    let advanceTo (spaceId : SpaceId) =
        let action (board : Board) (playerState : PlayerState) =
            let space = board.[spaceId]
            let position = board.PositionOf space
            { playerState with Position = position }
        action

    let advanceToNearestStation () = 
        let action (board : Board) (playerState : PlayerState) = 
            let playerPosition = playerState.Position
            let nearestPosition = board.Nearest playerPosition NearestStation
            // Pay the player
            { playerState with Position = nearestPosition }
        action

    let deck: ChanceCard list = [
        {
            Description = "Advance to Go (Collect £200)"
            Action = advanceTo SpaceId.Go
        };
        {
            Description = "Advance to Trafalgar Square. If you pass Go, collect £200"
            Action = advanceTo TrafalgarSquare
        };
        {
            Description = "Advance to Mayfair"
            Action = advanceTo Mayfair
        };
        {
            Description = "Advance to Pall Mall. If you pass Go, collect £200"
            Action = advanceTo PallMall
        };
        {
            Description = """Advance to the nearest Station. If unowned, you may buy it from the Bank. 
                             If owned, pay wonder twice the rental to which they are otherwise entitled."""
            Action = advanceToNearestStation ()

        };
        {
            Description = """Advance to the nearest Utility. If unowned, you may buy it from the Bank. 
                             If owned, throw dice and pay owner a total ten times amount thrown."""
            Action = fun board playerState -> playerState
        }
    ]

type ChanceCards(cards: ChanceCard list) =
    let cards = cards
    new () = ChanceCards ChanceCards.deck 