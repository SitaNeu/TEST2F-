// For more information see https://aka.ms/fsharp-console-apps
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

type Director = {
    Name: string
    Movies: int
}

type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    IMDBRating: float
}

let movies = [
    {
        Name = "CODA"
        RunLength = 111
        Genre = Drama
        Director = { Name = "Sian Heder"; Movies = 9 }
        IMDBRating = 8.1
    }
    {
        Name = "Belfast"
        RunLength = 98
        Genre = Comedy
        Director = { Name = "Kenneth Branagh"; Movies = 23 }
        IMDBRating = 7.3
    }
    {
        Name = "Don't Look Up"
        RunLength = 138
        Genre = Comedy
        Director = { Name = "Adam McKay"; Movies = 27 }
        IMDBRating = 7.2
    }
    {
        Name = "Drive My Car"
        RunLength = 179
        Genre = Drama
        Director = { Name = "Ryusuke Hamaguchi"; Movies = 16 }
        IMDBRating = 7.6
    }
    {
        Name = "Dune"
        RunLength = 155
        Genre = Fantasy
        Director = { Name = "Denis Villeneuve"; Movies = 24 }
        IMDBRating = 8.1
    }
    {
        Name = "King Richard"
        RunLength = 144
        Genre = Sport
        Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }
        IMDBRating = 7.5
    }
    {
        Name = "Licorice Pizza"
        RunLength = 133
        Genre = Comedy
        Director = { Name = "Paul Thomas Anderson"; Movies = 49 }
        IMDBRating = 7.4
    }
    {
        Name = "Nightmare Alley"
        RunLength = 150
        Genre = Thriller
        Director = { Name = "Guillermo Del Toro"; Movies = 22 }
        IMDBRating = 7.1
    }
]

printfn "Directors and Number of Movies Directed:"
movies 
|> List.map (fun movie -> movie.Director)
|> List.distinctBy (fun director -> director.Name)
|> List.iter (fun director -> printfn "%s: %d movies" director.Name director.Movies)
printfn " "


printfn "\nMovies, Directors, and IMDb Ratings:"
movies 
|> List.iter (fun movie -> printfn "Movie: %s, Director: %s, IMDb Rating: %.1f" movie.Name movie.Director.Name movie.IMDBRating)
printfn " "


let convertRunLength runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes

printfn "\nMovies and Their Run Lengths:"
movies 
|> List.iter (fun movie -> printfn "Movie: %s, Run Length: %s" movie.Name (convertRunLength movie.RunLength))

printfn " "


let probableOscarWinners = 
    movies 
    |> List.filter (fun movie -> movie.IMDBRating > 7.4)


printfn"The movies that are likely to win oscars are:"
probableOscarWinners |> List.iter (fun movie -> printfn "%s" movie.Name)
printfn " "
