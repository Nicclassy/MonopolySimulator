namespace MonopolySimulator.Types

type Board(spaces: Space array) =
    member private _.Spaces = spaces
    member private _.SpacesByName : Map<string, Space> = 
        spaces
        |> Array.map (fun space -> space.Name, space)
        |> Map.ofArray

    member this.Item
        with get (index: int) = this.Spaces.[index]

    member this.Item
        with get (index: string) = this.SpacesByName.[index]

    member this.Length = uint this.Spaces.Length

module Board = 
    let Default () = Board [|
        { Name = "Go"; Type = Go }
        { Name = "Old Kent Road"; Type = Street(Brown, 60u) }
        { Name = "Community Chest"; Type = CommunityChest }
        { Name = "Whitechapel Road"; Type = Street(Brown, 60u) }
        { Name = "Income Tax"; Type = Tax 200u }
        { Name = "King's Cross Station"; Type = Station 200u }
        { Name = "The Angel Islington"; Type = Street(LightBlue, 100u) }
        { Name = "Chance"; Type = Chance }
        { Name = "Euston Road"; Type = Street(LightBlue, 100u) }
        { Name = "Pentonville Road"; Type = Street(LightBlue, 120u) }
        { Name = "Visting Jail"; Type = VisitngJail }
        { Name = "Pall Mall"; Type = Street(Pink, 140u) }
        { Name = "Electric Company"; Type = Utility 150u }
        { Name = "Whitehall"; Type = Street (Pink, 140u) }
        { Name = "Northumberland Avenue"; Type = Street(Pink, 160u) }
        { Name = "Marylebone Station"; Type = Station 200u }
        { Name = "Bow Street"; Type = Street(Orange, 180u) }
        { Name = "Community Chest"; Type = CommunityChest }
        { Name = "Marlborough Street"; Type = Street(Orange, 180u) }
        { Name = "Vine Street"; Type = Street(Orange, 200u) }
        { Name = "Free Parking"; Type = FreeParking }
        { Name = "Strand"; Type = Street(Red, 220u) }
        { Name = "Chance"; Type = Chance }
        { Name = "Fleet Street"; Type = Street(Red, 220u) }
        { Name = "Trafalgar Square"; Type = Street(Red, 240u) }
        { Name = "Fenchurch Street Station"; Type = Station 200u }
        { Name = "Leicester Square"; Type = Street(Yellow, 260u) }
        { Name = "Coventry Street"; Type = Street(Yellow, 260u) }
        { Name = "Water Works"; Type = Utility 150u }
        { Name = "Piccadilly"; Type = Street(Yellow, 280u) }
        { Name = "Go To Jail"; Type = Jail }
        { Name = "Regent Street"; Type = Street(Green, 300u) }
        { Name = "Oxford Street"; Type = Street(Green, 300u) }
        { Name = "Community Chest"; Type = CommunityChest }
        { Name = "Bond Street"; Type = Street(Green, 320u) }
        { Name = "Liverpool Street Station"; Type = Station 200u }
        { Name = "Chance"; Type = Chance }
        { Name = "Park Lane"; Type = Street(DarkBlue, 350u) }
        { Name = "Super Tax"; Type = Tax 100u }
        { Name = "Mayfair"; Type = Street(DarkBlue, 400u) }
    |]

