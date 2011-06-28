Imports RockPaperScissorsPro

Public Class MyBot
    Implements IRockPaperScissorsBot

    ' Random sample implementation
    Public Function MakeMove(you As IPlayer, opponent As IPlayer, rules As GameRules) As Move Implements IRockPaperScissorsBot.MakeMove
        Return Moves.GetRandomMove()
    End Function

    ' Cycle sample implementation
    'Public Function MakeMove(you As IPlayer, opponent As IPlayer, rules As GameRules) As Move Implements IRockPaperScissorsBot.MakeMove
    '    If you.LastMove = Moves.Rock Then Return Moves.Paper

    '    If you.LastMove = Moves.Paper Then Return Moves.Scissors

    '    If you.LastMove = Moves.Scissors Then
    '        If you.HasDynamite Then
    '            Return Moves.Dynamite
    '        Else
    '            Return Moves.WaterBalloon
    '        End If
    '    End If

    '    If you.LastMove = Moves.Dynamite Then Return Moves.WaterBalloon

    '    Return Moves.Rock
    'End Function

    ' BigBang sample implementation
    'Public Function MakeMove(you As IPlayer, opponent As IPlayer, rules As GameRules) As Move Implements IRockPaperScissorsBot.MakeMove
    '    If you.NumberOfDecisions < 5 Then
    '        Return Moves.Dynamite
    '    Else
    '        Return Moves.GetRandomMove()
    '    End If
    'End Function
End Class