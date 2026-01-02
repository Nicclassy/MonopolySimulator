namespace MonopolySimulator.Types

type Colour = 
    | Brown
    | LightBlue
    | Pink
    | Orange
    | Red
    | Yellow
    | Green
    | DarkBlue

type SpaceId =
    | Go
    | OldKentRoad
    | FirstCommunityChest
    | WhitechapelRoad
    | IncomeTax
    | KingsCrossStation
    | TheAngelIslington
    | FirstChance
    | EustonRoad
    | PentonvilleRoad
    | VisitingJail
    | PallMall
    | ElectricCompany
    | Whitehall
    | NorthumberlandAvenue
    | MaryleboneStation
    | BowStreet
    | SecondCommunityChest
    | MarlboroughStreet
    | VineStreet
    | FreeParking
    | Strand
    | SecondChance
    | FleetStreet
    | TrafalgarSquare
    | FenchurchStreetStation
    | LeicesterSquare
    | CoventryStreet
    | Waterworks
    | Piccadilly
    | GoToJail
    | RegentStreet
    | OxfordStreet
    | ThirdCommunityChest
    | BondStreet
    | LiverpoolStreetStation
    | ThirdChance
    | ParkLane
    | SuperTax
    | Mayfair

type SpaceType =
    | Street of Colour : Colour * Cost : uint
    | Chance
    | CommunityChest
    | Utility of Cost : uint
    | VisitngJail
    | Jail
    | Station of Cost : uint
    | Tax of Amount : uint
    | FreeParking
    | Go

type Space = {
    Id: SpaceId
    Name: string
    Type: SpaceType
}