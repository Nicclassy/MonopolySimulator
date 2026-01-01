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
    Name: string
    Type: SpaceType
}