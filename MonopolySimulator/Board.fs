namespace MonopolySimulator.Types

type Board(spaces: Space array) =
    let spaces = spaces
    let spacesById: Map<SpaceId, Space> = 
        spaces
        |> Array.map (fun space -> space.Id, space)
        |> Map.ofArray

    let positionsBySpaceId: Map<SpaceId, uint> = 
        spaces
        |> Seq.mapi (fun position space -> space.Id, uint position)
        |> Map.ofSeq

    member _.Item
        with get (index: uint) = spaces[int index]

    member _.Item
        with get (index: SpaceId) = spacesById[index]

    member _.PositionOf space= positionsBySpaceId[space.Id]
    member _.Length = uint spaces.Length

module Board = 
    let Default () = Board [|
        { Id = SpaceId.Go; Name = "Go"; Type = Go }
        { Id = OldKentRoad; Name = "Old Kent Road"; Type = Street(Brown, 60u) }
        { Id = FirstCommunityChest; Name = "Community Chest"; Type = CommunityChest }
        { Id = WhitechapelRoad; Name = "Whitechapel Road"; Type = Street(Brown, 60u) }
        { Id = IncomeTax; Name = "Income Tax"; Type = Tax 200u }
        { Id = KingsCrossStation; Name = "King's Cross Station"; Type = Station 200u }
        { Id = TheAngelIslington; Name = "The Angel Islington"; Type = Street(LightBlue, 100u) }
        { Id = FirstChance; Name = "Chance"; Type = Chance }
        { Id = EustonRoad; Name = "Euston Road"; Type = Street(LightBlue, 100u) }
        { Id = PentonvilleRoad; Name = "Pentonville Road"; Type = Street(LightBlue, 120u) }
        { Id = VisitingJail; Name = "Visting Jail"; Type = VisitngJail }
        { Id = PallMall; Name = "Pall Mall"; Type = Street(Pink, 140u) }
        { Id = ElectricCompany; Name = "Electric Company"; Type = Utility 150u }
        { Id = Whitehall; Name = "Whitehall"; Type = Street(Pink, 140u) }
        { Id = NorthumberlandAvenue; Name = "Northumberland Avenue"; Type = Street(Pink, 160u) }
        { Id = MaryleboneStation; Name = "Marylebone Station"; Type = Station 200u }
        { Id = BowStreet; Name = "Bow Street"; Type = Street(Orange, 180u) }
        { Id = SecondCommunityChest; Name = "Community Chest"; Type = CommunityChest }
        { Id = MarlboroughStreet; Name = "Marlborough Street"; Type = Street(Orange, 180u) }
        { Id = VineStreet; Name = "Vine Street"; Type = Street(Orange, 200u) }
        { Id = SpaceId.FreeParking; Name = "Free Parking"; Type = FreeParking }
        { Id = Strand; Name = "Strand"; Type = Street(Red, 220u) }
        { Id = SecondChance; Name = "Chance"; Type = Chance }
        { Id = FleetStreet; Name = "Fleet Street"; Type = Street(Red, 220u) }
        { Id = TrafalgarSquare; Name = "Trafalgar Square"; Type = Street(Red, 240u) }
        { Id = FenchurchStreetStation; Name = "Fenchurch Street Station"; Type = Station 200u }
        { Id = LeicesterSquare; Name = "Leicester Square"; Type = Street(Yellow, 260u) }
        { Id = CoventryStreet; Name = "Coventry Street"; Type = Street(Yellow, 260u) }
        { Id = Waterworks; Name = "Water Works"; Type = Utility 150u }
        { Id = Piccadilly; Name = "Piccadilly"; Type = Street(Yellow, 280u) }
        { Id = GoToJail; Name = "Go To Jail"; Type = Jail }
        { Id = RegentStreet; Name = "Regent Street"; Type = Street(Green, 300u) }
        { Id = OxfordStreet; Name = "Oxford Street"; Type = Street(Green, 300u) }
        { Id = ThirdCommunityChest; Name = "Community Chest"; Type = CommunityChest }
        { Id = BondStreet; Name = "Bond Street"; Type = Street(Green, 320u) }
        { Id = LiverpoolStreetStation; Name = "Liverpool Street Station"; Type = Station 200u }
        { Id = ThirdChance; Name = "Chance"; Type = Chance }
        { Id = ParkLane; Name = "Park Lane"; Type = Street(DarkBlue, 350u) }
        { Id = SuperTax; Name = "Super Tax"; Type = Tax 100u }
        { Id = Mayfair; Name = "Mayfair"; Type = Street(DarkBlue, 400u) }
    |]


