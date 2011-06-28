namespace RockPaperAzure
open RockPaperScissorsPro

type MyBot() = class
    interface IRockPaperScissorsBot with
        member this.MakeMove(y, o, r) = this.MakeMove(y, o, r)
    end

    // Random sample implementation
    member this.MakeMove(you: IPlayer, opponent: IPlayer, rules: GameRules) = Moves.GetRandomMove()

    // Cycle sample implementation
//    member this.MakeMove(you: IPlayer, opponent: IPlayer, rules: GameRules) = 
//        match (match you.LastMove with
//                | null -> ""
//                | _ -> you.LastMove.ToString().ToLower()) with
//        | "rock" -> Moves.Paper
//        | "paper" -> Moves.Scissors
//        | "scissors" -> if you.HasDynamite then
//                           Moves.Dynamite
//                        else
//                           Moves.WaterBalloon
//        | "dynamite" -> Moves.WaterBalloon
//        | _ -> Moves.Rock

    // BigBang sample implementation
//    member this.MakeMove(you: IPlayer, opponent: IPlayer, rules: GameRules) =
//        match you.NumberOfDecisions with 
//        | five when five < 5 -> Moves.Dynamite
//        | _ -> Moves.GetRandomMove()
end