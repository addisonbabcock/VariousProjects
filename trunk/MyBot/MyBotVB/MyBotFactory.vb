Imports Compete.Bot

''********************************************
''  
''  This file should not be modified.
''  Code your move logic in MyBot.vb
''  
''********************************************

Namespace RockPaperAzure

    Public Class MyBotFactory
        Implements IBotFactory

        Public Function CreateBot() As IBot Implements IBotFactory.CreateBot
            Return New MyBot()
        End Function
    End Class
End Namespace