' CASHCALC 2.6
' Tab stops: 2
' Additions since 2.5:
' Quick review all possibilities
' Additions since 1.5:
' Optional output results to file
' Optional pause
' Optional combination display
' Planned additions in 3.0:
' Ability to "filter" results

' If anyone knows a faster way to do this, email corkhead0@hotmail.com









CLS
PRINT "Cashcalc 2.5"
PRINT "By Addison Babcock"
PRINT "Calculates all possibilities of each coin from a given total"
startTime! = TIMER
WHILE TIMER - startTime! < 2.5: WEND
CLS

INPUT "Enter total amount of money in pennies. ", total
IF total < 0 THEN
PRINT "You can't have negative pennies!"
END
END IF

IF total <= 470 THEN ' Do not adjust this section
PRINT "Enable quick review (Recommended)? (Y / N) "
DO ' It was put through many tests to get
key$ = UCASE$(LEFT$(INKEY$, 1)) ' the right numbers and push QBasic
LOOP UNTIL key$ = "Y" OR key$ = "N" ' to its limits.
review$ = key$
IF key$ = "Y" THEN
max = 16383
DIM Qa(max), Da(max), Na(max), Pa(max)
END IF
ELSE
review$ = "N"
END IF

IF total > 1000 THEN
CLS
COLOR 20
PRINT "WARNING! WARNING!"
COLOR 7
PRINT "This will take a very long time unless you have a fast computer!"
PRINT "Continue?"
DO
k$ = UCASE$(INKEY$)
LOOP UNTIL k$ = "Y" OR k$ = "N"
IF k$ = "N" THEN
PRINT "Program stopped."
END
END IF
END IF

CLS

PRINT "Display results on screen (Y/N)? "
DO
k$ = UCASE$(INKEY$)
LOOP UNTIL k$ = "Y" OR k$ = "N"
Disp$ = k$
k$ = ""

IF Disp$ = "Y" THEN
PRINT "Pause after each possible answer (Y/N)? "
DO
k$ = UCASE$(INKEY$)
LOOP UNTIL k$ = "Y" OR k$ = "N"
Pause$ = k$
k$ = ""
END IF

PRINT "Output results to a file (Y/N)? "
DO
k$ = LEFT$(UCASE$(INKEY$), 1)
LOOP UNTIL k$ = "Y" OR k$ = "N"
Output$ = k$
k$ = ""

IF Output$ = "Y" THEN
INPUT "Enter full path ", File$
OPEN File$ FOR OUTPUT AS #1
END IF

CLS
PRINT "Calculating..."

WHILE total / 5 <> INT(total / 5)
Calcs = Calcs + 1
P = P + 1
total = total - 1
WEND

MaxQ = INT(total / 25)
MaxD = INT(total / 10)
MaxN = INT(total / 5)
Calcs = Calcs + 3

WHILE total >= 0

FOR Q = 0 TO MaxQ
FOR D = 0 TO MaxD
FOR N = 0 TO MaxN
IF (Q * 25) + (D * 10) + (N * 5) = total THEN
IF Disp$ = "Y" THEN
PRINT "Q:"; Q; "D:"; D; "N:"; N; "P:"; P
END IF
IF Output$ = "Y" THEN
PRINT #1, "Q:"; Q; "D:"; D; "N:"; N; "P:"; P
END IF
posi = posi + 1
IF review$ = "Y" THEN
Qa(posi) = Q
Da(posi) = D
Na(posi) = N
Pa(posi) = P
END IF
IF Pause$ = "Y" THEN
SLEEP
END IF
END IF
'Calcs = Calcs + 1
NEXT
NEXT
NEXT
P = P + 5
total = total - 5
MaxQ = INT(total / 25)
MaxD = INT(total / 10)
MaxN = INT(total / 5)

WEND

PRINT "Total possibilities: "; posi

IF Output$ = "Y" THEN
PRINT #1, "Total possibilities: "; posi
CLOSE #1
END IF

PRINT ""
PRINT "Done."

WHILE k$ = ""
k$ = INKEY$
WEND

IF review$ = "N" THEN
GOTO TheEnd
END IF

review:
PRINT "Would you like to review any results? (Y/N)"
key$ = ""
DO
key$ = UCASE$(LEFT$(INKEY$, 1))
LOOP UNTIL key$ = "Y" OR key$ = "N"
IF key$ = "Y" THEN
CLS
PRINT "Enter result (0 for all)#"
LOCATE 1, 26
INPUT "", result
IF result <= posi THEN
IF result = 0 THEN
INPUT "Review speed"; delay!
FOR result = 1 TO posi
PRINT "Q:"; Qa(result); "D:"; Da(result); "N:"; Na(result); "P:"; Pa(result)
FOR I = 0 TO delay: NEXT I
NEXT result
GOTO review
END IF
PRINT "Q:"; Qa(result); "D:"; Da(result); "N:"; Na(result); "P:"; Pa(result)
ELSE
PRINT "Error: There aren't that many results!"
END IF
GOTO review
END IF


TheEnd:
CLS
FOR I = 1 TO 10: PRINT "": NEXT I
PRINT " Soon to come in CASHCALC 3.0"
PRINT " +Formula limitations!"
PRINT " +Maybe a faster algorithm!"
PRINT ""
PRINT ""
PRINT " Go to members.fortunecity.com/corkhead0/index.html"
PRINT " for more information."
'******************************************************
