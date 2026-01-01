namespace MonopolySimulator.Types

type Character = 
    | Dinosaur
    | Battleship
    | Penguin
    | Dog
    | Cat
    | Hat
    | Duck
    | Car

type Player = { 
    Name: string 
    Character: Character
}