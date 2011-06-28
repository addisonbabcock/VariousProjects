//********************************************
//
//  This file should not be modified.
//  Code your move logic in MyBot.fs
//  
//********************************************

namespace RockPaperAzure
open Compete.Bot

type MyBotFactory() = class
    interface IBotFactory with
        member this.CreateBot() = new MyBot() :> IBot
end